using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterInterface
{
    class Global
    {
        public static MySQL.MySQLHelper mysqlHelper1 = new MySQL.MySQLHelper("localhost", "check_weighter_data_analysis", "root", "ei41");

        //public delegate void BrandChangedReinit(object sender, EventArgs e);
        //public static event BrandChangedReinit brandChangedReInitStatusMonitor;
        //public static event BrandChangedReinit brandChangedReInitTimeDomainAnalysis;
        //public static event BrandChangedReinit brandChangedReInitFrequencyDomainAnalysis;
        //public static event BrandChangedReinit brandChangedReInitExcelExport;
        //public static event BrandChangedReinit brandChangedReInitSystemConfig;

        //状态参数
        public struct Status{
           public string brand;                         //品牌
           public double curWeight;                     //当前重量
           public string flagOverWeightOrUnderWeight;   //超重、欠重标志字符串
           public double lastOverWeight;                //上次超重
           public double lastUnderWeight;               //上次欠重
           public Int32 countDetection;                 //检测数量
           public Int32 countOverWeight;                //超重数量
           public Int32 countUnderWeight;               //欠重数量
           public double maxWeightInHistory;            //最大值
           public double minWeightInHistory;            //最小值
        };
        public static Status curStatus = new Status();      //当前状态
         
        public static double underWeightThreshold;         //欠重阈值（设定值为初始值）
        public static double overWeightThreshold;          //超重阈值（设定值为初始值）



        public static void initMySQL()
        {
            if (!mysqlHelper1._connectMySQL())
            {
                MessageBox.Show("数据库连接失败");
            }
        }

        //将当前状态写入MySQL
        public static void insertCurStatusMySQL()
        {
            string cmdInsertStatus = "INSERT INTO weight_history (Brand, Weight, Status, DateTime) VALUES ("
                                     + "'" + curStatus.brand + "'" + ", " + curStatus.curWeight.ToString() + ", " + "'" + curStatus.flagOverWeightOrUnderWeight + "'" + ", CURRENT_TIMESTAMP());";
            bool flag = mysqlHelper1._insertMySQL(cmdInsertStatus);
        }

        //查询
        public static void queryStatusHistoryMySQL(string st, string et, ref DataTable dt)
        {
            string cmdQueryLineHistoryMySQL = "CALL queryLineHistoryMySQL('" + st + "', '" + et + "');";
            Global.mysqlHelper1._queryTableMySQL(cmdQueryLineHistoryMySQL, ref dt);
        }

        public static void reorderDt(ref DataTable dt, string colNOName)
        {
            int lenDt = dt.Rows.Count;
            for (int i = 0; i < lenDt; i++)
            {
                dt.Rows[i][colNOName] = (i + 1).ToString();
            }
        }





    }
}
