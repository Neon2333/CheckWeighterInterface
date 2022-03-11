using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterInterface
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        //DataTable dtBrand = new DataTable("dtBrand");

        DateTime now = new DateTime();

        private StatusMonitor.StatusMonitor statusMonitor1;
        private DataAnalysis.DataAnalysis dataAnalysis1;
        private ExcelExport.ExcelExport excelExport1;
        private SystemConfig.SystemConfig systemConfig1;


        private CommonControl.ConfirmationBox confirmationBox_applicationClose;

        enum modulePage { statusMonitor = 0, dataAnalysis, exportExcel, sysConfig};
        private NavigationPage[] modulePages = new NavigationPage[4];

        enum DataAnalysisPage { timeDomainAnalysis = 0, frequencyDomainAnalysis};

        public MainForm()
        {
            InitializeComponent();
            initMainForm();
        }

        private void timer_datetime_Tick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            this.labelControl_datetime.Text = now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        private void initMainForm()
        {
            Global.initMySQL();

            Global.mysqlHelper1._updateMySQL("TRUNCATE TABLE weight_history;");     //清空原先品牌的重量历史
            //Global.mysqlHelper1._queryTableMySQL("SELECT * FROM brand", ref dtBrand);
            //if(dtBrand.Rows.Count == 0)
            //{
            //    MessageBox.Show("请在数据库中至少添加一个品牌");
            //    Process.GetCurrentProcess().Kill();
            //}

            _loadModules(); 
            _initPages();


        }

        private void _loadModules()
        {
            //statusMonitor
            statusMonitor1 = new StatusMonitor.StatusMonitor();
            this.statusMonitor1.Location = new System.Drawing.Point(0, 0);
            this.statusMonitor1.Name = "statusMonitor2";
            this.statusMonitor1.Size = new System.Drawing.Size(1024, 617);
            this.statusMonitor1.TabIndex = 0;
            this.navigationPage_statusMonitor.Controls.Add(statusMonitor1);
            //dataAnalysis
            dataAnalysis1 = new DataAnalysis.DataAnalysis();
            this.dataAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.dataAnalysis1.Name = "statusMonitor2";
            this.dataAnalysis1.Size = new System.Drawing.Size(1024, 617);
            this.dataAnalysis1.TabIndex = 1;
            this.navigationPage_dataAnalysis.Controls.Add(dataAnalysis1);
            //excelExport
            excelExport1 = new ExcelExport.ExcelExport();
            this.excelExport1.Location = new System.Drawing.Point(0, 0);
            this.excelExport1.Name = "statusMonitor2";
            this.excelExport1.Size = new System.Drawing.Size(1024, 617);
            this.excelExport1.TabIndex = 2;
            this.navigationPage_exportExcel.Controls.Add(excelExport1);
            //systemConfig
            systemConfig1 = new SystemConfig.SystemConfig();
            this.systemConfig1.Location = new System.Drawing.Point(0, 0);
            this.systemConfig1.Name = "statusMonitor2";
            this.systemConfig1.Size = new System.Drawing.Size(1024, 617);
            this.systemConfig1.TabIndex = 3;
            this.navigationPage_sysConfig.Controls.Add(systemConfig1);

        }

        private void _initPages()
        {
            modulePages[0] = navigationPage_statusMonitor;
            modulePages[1] = navigationPage_dataAnalysis;
            modulePages[2] = navigationPage_exportExcel;
            modulePages[3] = navigationPage_sysConfig;
        }

        private void showCloseConfirmBox(string title, string typeConfirmationBox)
        {
            if (this.confirmationBox_applicationClose != null)
                this.confirmationBox_applicationClose.Dispose();

            this.confirmationBox_applicationClose = new CommonControl.ConfirmationBox();
            this.confirmationBox_applicationClose.Appearance.BackColor = System.Drawing.Color.White;
            this.confirmationBox_applicationClose.Appearance.Options.UseBackColor = true;
            this.confirmationBox_applicationClose.Name = "confirmationBox_applicationClose";
            this.confirmationBox_applicationClose.Size = new System.Drawing.Size(350, 150);
            this.confirmationBox_applicationClose.Location = new Point(337, 250);
            this.confirmationBox_applicationClose.TabIndex = 29;
            this.confirmationBox_applicationClose.titleConfirmationBox = title;
            this.confirmationBox_applicationClose.ConfirmationBoxOKClicked += new CommonControl.ConfirmationBox.SimpleButtonOKClickHanlder(this.confirmationBox_applicationRestart_closeOK);
            this.confirmationBox_applicationClose.ConfirmationBoxCancelClicked += new CommonControl.ConfirmationBox.SimpleButtonCancelClickHanlder(this.confirmationBox_applicationRestart_closeCancel);
            this.Controls.Add(this.confirmationBox_applicationClose);
            this.confirmationBox_applicationClose.Visible = true;
            this.confirmationBox_applicationClose.BringToFront();
        }

        private void confirmationBox_applicationRestart_closeOK(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void confirmationBox_applicationRestart_closeCancel(object sender, EventArgs e)
        {
        }

        private void tileBarItem_statusMonitor_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.statusMonitor];
        }

       

        private void tileBarItem_exportExcel_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.exportExcel];
        }

        private void tileBarItem_sysConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysConfig];
        }

        private void pictureEdit_CETC_DoubleClick(object sender, EventArgs e)
        {
            showCloseConfirmBox("确认关闭软件？", "close");
        }

        /**
       **********************************************点击磁贴，显示二级子菜单按钮***********************************************************
       */
        private void tileBarItem_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_dataAnalysis);
        }

        /**
       **********************************************点击二级子菜单按钮后，子菜单按钮隐藏***********************************************************
       */
        private void tileBar_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        /**
        *******************************************************二级子菜单显示***************************************************************
        */
        private void tileBarItem_dataAnalysis_timeDomainAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.dataAnalysis];
            this.dataAnalysis1.selectedFramePage = (int)DataAnalysisPage.timeDomainAnalysis;
        }

        private void tileBarItem_dataAnalysis_frequencyDomainAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.dataAnalysis];
            this.dataAnalysis1.selectedFramePage = (int)DataAnalysisPage.frequencyDomainAnalysis;

        }
    }
}