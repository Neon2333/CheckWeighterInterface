using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterInterface.StatusMonitor
{
    public partial class StatusMonitor : DevExpress.XtraEditors.XtraUserControl
    {
        private DataTable dtBrand = new DataTable("tableBrand");

        public static DataTable dtLine = new DataTable("tableLine");    //折线图数据源，只显示200个点
        private DataTable dtPie = new DataTable("tablePie");            //饼图数据源，只要不更换brand就一直累计
        private DataTable dtPoint = new DataTable("tablePoint");        //散点图数据源，只要不更换brand就一直累计
        private double lastOverWeght = 0.0D;
        private double lastUnderWeight = 0.0D;

        Dictionary<int, int> weightAndIndexGramDtPoint = new Dictionary<int, int>();    //(weight, totalDtPoint)
        private int totalDtPoint = 0;       //dtPoint中存的点的个数（行数，重量不同才会增加一行）
        //散点图横轴坐标边缘
        private Int32[] minXRangePoint = { 0, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000 };
        private Int32[] maxXRangePoint = { 0, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000 };
        private Int32 minXPoint = 0;    //横轴范围左侧
        private Int32 maxXPoint = 0;   //横轴范围右侧

        //散点图坐标轴取值范围
        public Int32 minPointXLeft = 9;     
        public Int32 minPointXRight = 13;


        //散点图横轴分辨率档位
        private Int32[] intervalAxisXPoint = {10, 20, 50, 100};     //散点图横轴分辨率
        private Int32 gearIntervalAxisXPoint = 0;                    //散点图横轴档位

        public bool getTimerDetectOnceEnable()
        {
            return this.timer_detectOnce.Enabled;
        }

        public void setTimerDetectOnceEnable(bool val)
        {
            this.timer_detectOnce.Enabled = val;
        }

        public StatusMonitor()
        {
            InitializeComponent();
            initStatusMonitor();
            SystemManagement.BrandManagement.brandChangedReInitStatusMonitor += reInitStatusMonitor;
        }


        //初始化StatusMonitor
        private void initStatusMonitor()
        {
            //数据库中无品牌时不刷新实时图表
            string cmdInitDtBrand = "SELECT * FROM brand;";
            Global.mysqlHelper1._queryTableMySQL(cmdInitDtBrand, ref dtBrand);
            if (dtBrand.Rows.Count == 0)
            {
                timer_detectOnce.Enabled = false;
            }
            else
            {
                timer_detectOnce.Enabled = true;

                Global.curStatus.brand = dtBrand.Rows[0]["name"].ToString();
                Global.curStatus.countDetection = 0;
                Global.curStatus.countOverWeight = 0;
                Global.curStatus.countUnderWeight = 0;
                Global.curStatus.lastOverWeight = 0.0D;
                Global.curStatus.lastUnderWeight = 0.0D;
                Global.curStatus.maxWeightInHistory = 0.0D;
                Global.curStatus.minWeightInHistory = 20.0D;

                Global.overWeightThreshold = Convert.ToDouble(dtBrand.Rows[0]["upperLimit"]);
                Global.underWeightThreshold = Convert.ToDouble(dtBrand.Rows[0]["lowerLimit"]);

                initDatatable();
                bindLineData();
                bindPieData();

                setAxisXMinMaxPoint(minPointXLeft, minPointXRight);  //设定散点图横轴区间范围
                setGearIntervalAxisXPoint(0);   //设定散点图横轴分辨率
                bindPointData();
                labelControl_status.Parent = this.chartControl_line;
                labelControl_curWeightVal.Parent = this.chartControl_line;
            }
        }

        //当前品牌发生改变时，刷新页面函数
        private void reInitStatusMonitor(object sender, EventArgs e)
        {
            Global.mysqlHelper1._updateMySQL("TRUNCATE TABLE weight_history;");     //清空原先品牌的重量历史
            weightAndIndexGramDtPoint.Clear();                                      //清空字典
            totalDtPoint = 0;

            if (Global.curStatus.brand != "")
            {
                timer_detectOnce.Enabled = true;

                Global.curStatus.countDetection = 0;
                Global.curStatus.countOverWeight = 0;
                Global.curStatus.countUnderWeight = 0;
                Global.curStatus.lastOverWeight = 0.0D;
                Global.curStatus.lastUnderWeight = 0.0D;
                Global.curStatus.maxWeightInHistory = 0.0D;
                Global.curStatus.minWeightInHistory = 20.0D;

                //initDatatable();
                dtLine.Rows.Clear();
                dtPie.Rows.Clear();
                dtPoint.Rows.Clear();

                initDatatable();
                bindLineData();
                bindPieData();

                setAxisXMinMaxPoint(minPointXLeft, minPointXRight);  //设定散点图横轴区间范围
                setGearIntervalAxisXPoint(0);   //设定散点图横轴分辨率
                bindPointData();
                labelControl_status.Parent = this.chartControl_line;
                labelControl_curWeightVal.Parent = this.chartControl_line;

                //MessageBox.Show("refresh");
            }
            else
            {
                timer_detectOnce.Enabled = false;
            }

            
        }

        //初始化数据源DataTable
        private void initDatatable()
        {
            //添加一次称重数据
            if (dtLine.Columns.Count == 0)
            {
                dtLine.Columns.Add("countDetection", typeof(Int32));        //称重计数
                dtLine.Columns.Add("currentWeight", typeof(double));        //当前重量
            }

            if (dtPie.Columns.Count == 0)
            {
                dtPie.Columns.Add("status", typeof(String));                //状态：欠重、超重、正常
                dtPie.Columns.Add("countCur", typeof(Int32));
            }

            if(dtPoint.Columns.Count == 0)
            {
                dtPoint.Columns.Add("weightSection", typeof(Int32));        //重量区间
                dtPoint.Columns.Add("countInSection", typeof(Int32));       //计数区间
            }
        }

        //绑定折线图数据源，以及图表相关设置
        private void bindLineData()
        {
            this.chartControl_line.Series[0].DataSource = dtLine;      //绑定Datatable
            this.chartControl_line.Series[0].ArgumentScaleType = ScaleType.Numerical;   //设定Argument的类型
            this.chartControl_line.Series[0].ArgumentDataMember = "countDetection";       //设定Argument的字段名
            this.chartControl_line.Series[0].ValueScaleType = ScaleType.Numerical;  //设定Value的类型
            this.chartControl_line.Series[0].ValueDataMembers.AddRange(new string[] { "currentWeight" });   
        }

        //绑定饼图数据源，以及图表相关设置
        private void bindPieData()
        {
            this.chartControl_pie.Series[0].DataSource = dtPie;
            this.chartControl_pie.Series[0].ArgumentDataMember = "status";
            this.chartControl_pie.Series[0].ArgumentScaleType = ScaleType.Auto;
            this.chartControl_pie.Series[0].ValueDataMembers.AddRange(new string[] { "countCur" });
            this.chartControl_pie.Series[0].ValueScaleType = ScaleType.Numerical;
            this.chartControl_pie.Series[0].LegendTextPattern = "{A}：{VP:p2}";  //图例格式"Argument:Value"。V:n2为Value:numeric小数点后2位，VP:p2为Value:percent小数点后2位
        }

        //绑定点图数据源，以及图表相关设置
        private void bindPointData()
        {
            this.chartControl_point.Series[0].DataSource = dtPoint;
            this.chartControl_point.Series[0].ArgumentScaleType = ScaleType.Auto;
            this.chartControl_point.Series[0].ArgumentDataMember = "weightSection";
            this.chartControl_point.Series[0].ValueScaleType = ScaleType.Numerical;
            this.chartControl_point.Series[0].ValueDataMembers.AddRange(new string[] { "countInSection" });
        }

        //获取当前重量和H-/L-/p-状态
        private void getCurWeight()
        {
            //数据生成
            Global.curStatus.countDetection++;
            Random rnd = new Random();
            //double cw = rnd.Next(8, 12) + rnd.Next(0, 9) * 0.1 + rnd.Next(0, 9) * 0.01 + rnd.Next(0, 9) * 0.001;
            double cw = createRandomProbability(90, 8, 12, 13) + rnd.Next(0, 9) * 0.1 + rnd.Next(0, 9) * 0.01 + rnd.Next(0, 9) * 0.001;

            //更新当前重量、超重/欠重/正常标志
            Global.curStatus.curWeight = cw;
            if (Global.curStatus.curWeight > Global.overWeightThreshold)
                Global.curStatus.flagOverWeightOrUnderWeight = "H-";
            else if (Global.curStatus.curWeight < Global.underWeightThreshold)
                Global.curStatus.flagOverWeightOrUnderWeight = "L-";
            else
                Global.curStatus.flagOverWeightOrUnderWeight = "p-";
            
            labelControl_curWeightVal.Text = Global.curStatus.curWeight.ToString() + "KG";          //刷新重量显示
            labelControl_detectionCountVal.Text = Global.curStatus.countDetection.ToString();       //刷新检测数量
        }

        //刷新最值
        private void updateMinWeightAndMaxWeight()
        {
            //刷新最大值
            if (Global.curStatus.curWeight > Global.curStatus.maxWeightInHistory)
            {
                Global.curStatus.maxWeightInHistory = Global.curStatus.curWeight;
                labelControl_maxWeightInHistory.Text = Global.curStatus.maxWeightInHistory != 0.0D ? Global.curStatus.maxWeightInHistory.ToString() : "";
            }
            //刷新最小值
            if (Global.curStatus.curWeight < Global.curStatus.minWeightInHistory)
            {
                Global.curStatus.minWeightInHistory = Global.curStatus.curWeight;
                labelControl_minWeightInHistory.Text = Global.curStatus.minWeightInHistory != 20.0D ? Global.curStatus.minWeightInHistory.ToString() : "";
            }
        }

        //刷新上次欠重、上次超重
        private void updateLastOverWeightAndLastUnderWeight()
        {
            //超重、欠重
            if (Global.curStatus.flagOverWeightOrUnderWeight == "H-")
            {
                Global.curStatus.countOverWeight++;
                labelControl_status.Text = "NG";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));

                Global.curStatus.lastOverWeight = lastOverWeght;    //超重、欠重都要更新，否则出现类似场景：第一次是超重，后面一直是欠重，则超重一直得不到刷新
                Global.curStatus.lastUnderWeight = lastUnderWeight;

                lastOverWeght = Global.curStatus.curWeight;
            }
            else if (Global.curStatus.flagOverWeightOrUnderWeight == "L-")
            {
                Global.curStatus.countUnderWeight++;
                labelControl_status.Text = "NG";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));

                Global.curStatus.lastOverWeight = lastOverWeght;
                Global.curStatus.lastUnderWeight = lastUnderWeight;

                lastUnderWeight = Global.curStatus.curWeight;
            }
            else if (Global.curStatus.flagOverWeightOrUnderWeight == "p-")
            {
                Global.curStatus.lastOverWeight = lastOverWeght;
                Global.curStatus.lastUnderWeight = lastUnderWeight;

                labelControl_status.Text = "OK";
                this.labelControl_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(152)))), ((int)(((byte)(83)))));
            }

            labelControl_underWeightCountVal.Text = Global.curStatus.countUnderWeight.ToString();
            labelControl_lastUnderWeightVal.Text = Global.curStatus.lastUnderWeight > 0.0D ? Global.curStatus.lastUnderWeight.ToString() : "";
            labelControl_overWeightCountVal.Text = Global.curStatus.countOverWeight.ToString();
            labelControl_lastOverWeightVal.Text = Global.curStatus.lastOverWeight > 0.0D ? Global.curStatus.lastOverWeight.ToString() : "";
        }

        //刷新折线图数据源
        private void updateChartLineData()
        {
            //点总数未到200时直接添加，超过200时添加一个点：删掉原有第1行，在最后添加一行
            if(Global.curStatus.countDetection <= 200)
            {
                DataRow drCurWeight = dtLine.NewRow();
                drCurWeight["countDetection"] = Global.curStatus.countDetection;
                drCurWeight["currentWeight"] = Global.curStatus.curWeight;
                dtLine.Rows.Add(drCurWeight);
            }
            else
            {
                dtLine.Rows.RemoveAt(0);
                DataRow drCurWeight = dtLine.NewRow();
                drCurWeight["countDetection"] = Global.curStatus.countDetection;
                drCurWeight["currentWeight"] = Global.curStatus.curWeight;
                dtLine.Rows.Add(drCurWeight);

                for(int i = 0; i < 200; i++)
                {
                    dtLine.Rows[i]["countDetection"] = (i + 1).ToString();
                }
            }
        }

        //刷新Pie图数据源，Pie图绑定数值，自动显示占比
        private void updateChartPieData()
        {
            if (dtPie.Rows.Count == 0)
            {
                DataRow drCountUnderWeight = dtPie.NewRow();
                drCountUnderWeight["status"] = "欠重";
                drCountUnderWeight["countCur"] = Global.curStatus.countUnderWeight;
                dtPie.Rows.Add(drCountUnderWeight);

                DataRow drCountOverWeight = dtPie.NewRow();
                drCountOverWeight["status"] = "超重";
                drCountOverWeight["countCur"] = Global.curStatus.countOverWeight;
                dtPie.Rows.Add(drCountOverWeight);

                DataRow drCountNormal = dtPie.NewRow();
                drCountNormal["status"] = "正常";
                drCountNormal["countCur"] = Global.curStatus.countDetection - Global.curStatus.countOverWeight - Global.curStatus.countUnderWeight;
                dtPie.Rows.Add(drCountNormal);
            }
            else
            {
                dtPie.Rows[0]["countCur"] = Global.curStatus.countUnderWeight;
                dtPie.Rows[1]["countCur"] = Global.curStatus.countOverWeight;
                dtPie.Rows[2]["countCur"] = Global.curStatus.countDetection - Global.curStatus.countOverWeight - Global.curStatus.countUnderWeight;
            }
        }

        //刷新Point图数据源
        private void updateChartPointData()
        {
            int indexDtPointTemp = 0;
            int weightGram = weightIntervalProcess(Global.curStatus.curWeight);
            //int weightGram = Convert.ToInt32(Global.curStatus.curWeight);
            if (weightAndIndexGramDtPoint.ContainsKey(weightGram) == false)
            {
                DataRow dr = dtPoint.NewRow();
                dr["weightSection"] = weightGram;
                dr["countInSection"] = 1;
                dtPoint.Rows.Add(dr);
                weightAndIndexGramDtPoint.Add(weightGram, totalDtPoint);
                totalDtPoint++;
            }
            else
            {
                indexDtPointTemp = weightAndIndexGramDtPoint[weightGram];
                dtPoint.Rows[indexDtPointTemp]["countInSection"] = Convert.ToInt32(dtPoint.Rows[indexDtPointTemp]["countInSection"]) + 1;
            }
        }

        //设置散点图横轴坐标范围
        private void setAxisXMinMaxPoint(int minKilogram, int maxKilogram)
        {
            if (minKilogram < maxKilogram)
            {
                minXPoint = minXRangePoint[minKilogram];
                maxXPoint = maxXRangePoint[maxKilogram];
                XYDiagram diagram = (XYDiagram)this.chartControl_point.Diagram;
                diagram.AxisX.WholeRange.SetMinMaxValues(minXPoint, maxXPoint);
            }
            else
            {
                MessageBox.Show("请输入合适的重量显示范围");
            }

        }

        //设置散点图横轴分辨率档位
        private void setGearIntervalAxisXPoint(int gear)
        {
            if (gear <= 3 && gear >= 0)
            {
                gearIntervalAxisXPoint = gear;
            }
            else
            {
                MessageBox.Show("请输入正确的档位");
                throw new Exception();
            }
        }

        //将重量（KG)按照区间划归
        private int weightIntervalProcess(double weightKilogram)
        {
            //小于minXPoint的设为minXPoint，大于maxXPoint的设为maxXPoint
            int weightgram = Convert.ToInt32(weightKilogram * 1000);
            int weight = 0;
            if (weightgram <= minXPoint)
            {
                weight = minXPoint;
            }
            else if(weightgram >= maxXPoint)
            {
                weight = maxXPoint;
            }
            else
            {
                int countInterval = (weightgram - minXPoint) / intervalAxisXPoint[gearIntervalAxisXPoint];
                int remainder = (weightgram - minXPoint) % intervalAxisXPoint[gearIntervalAxisXPoint];
                int intervalDeviceTwo = intervalAxisXPoint[gearIntervalAxisXPoint] / 2;
                if (remainder < intervalDeviceTwo)
                {
                    weight = minXPoint + countInterval * intervalAxisXPoint[gearIntervalAxisXPoint];
                }
                else
                {
                    weight = minXPoint + (1 + countInterval) * intervalAxisXPoint[gearIntervalAxisXPoint];
                }
            }

            return weight;
        }

        //将当前重量状态的原始数据插入MySQL
        private void insertCurStatusIntoMySQL()
        {
            Thread threadInsertMySQL = new Thread(new ThreadStart(Global.insertCurStatusMySQL));
            threadInsertMySQL.IsBackground = true;
            threadInsertMySQL.Name = "threadInsertMySQL" + Global.curStatus.countDetection.ToString();
            threadInsertMySQL.Start();
        }

        private int createRandomProbability(int probability, int a, int b, int c)
        {
            //以概率probablity生成[a,b]区间数，1-probablity概率生成[b,c]区间数
            Random myRandom = new Random();
            int i = myRandom.Next(1, 100);
            if (i <= probability)
            {
                int j = myRandom.Next(a, b);
                return j;
            }
            else
            {
                int j = myRandom.Next(b + 1, c);
                return j;
            }
        }

        //主循环
        private void timer_detectOnce_Tick(object sender, EventArgs e)
        {
            labelControl_brandVal.Text = Global.curStatus.brand;
            if(Global.curStatus.brand != "")
            {
                getCurWeight();                             //获取当前重量和显示
                updateMinWeightAndMaxWeight();              //刷新最值和显示
                updateLastOverWeightAndLastUnderWeight();   //刷新欠重/超重的重量、数值和显示
                updateChartLineData();                      //刷新折线图
                updateChartPieData();                       //刷新饼图
                updateChartPointData();                     //刷新点图
                insertCurStatusIntoMySQL();                 //插入MySQL
            }
            else
            {
                dtLine.Rows.Clear();
                dtPie.Rows.Clear();
                dtPoint.Rows.Clear();
                labelControl_lastOverWeightVal.Text = "";
                labelControl_lastUnderWeightVal.Text = "";
                labelControl_detectionCountVal.Text = "0";
                labelControl_overWeightCountVal.Text = "";
                labelControl_underWeightCountVal.Text = "";
                labelControl_maxWeightInHistory.Text = "";
                labelControl_minWeightInHistory.Text = "";
                labelControl_curWeightVal.Text = "";
                labelControl_status.Text = "";
            }
        }

        private void labelControl_status_Click(object sender, EventArgs e)
        {
            this.timer_detectOnce.Enabled = !this.timer_detectOnce.Enabled;
        }

        private void chartControl_line_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("export chartLine");
            //this.chartControl_line.ExportToXlsx(@"C:\Users\eivision\Desktop\a.xlsx");
        }

        private void chartControl_pie_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("export pie");
        }

        private void chartControl_point_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("export point");
        }



    }
}
