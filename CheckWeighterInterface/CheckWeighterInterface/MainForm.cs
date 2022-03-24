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
        DateTime now = new DateTime();

        private StatusMonitor.StatusMonitor statusMonitor1;
        private DataAnalysis.DataAnalysis dataAnalysis1;
        private ExcelExport.ExcelExport excelExport1;
        private ParameterConfig.ParameterConfig paraConfig1;
        private SystemManagement.SystemManagement systemManagement1;
        private SystemTest.SystemTest systemTest1;

        private CommonControl.ConfirmationBox confirmationBox_applicationClose;

        enum modulePage { statusMonitor = 0, dataAnalysis, exportExcel, paraConfig, sysConfig, sysTest};  
        private NavigationPage[] modulePages = new NavigationPage[6];

        enum DataAnalysisPage { timeDomainAnalysis = 0, frequencyDomainAnalysis};
        enum ParaConfigPage { benchmarkConfig = 0, algorithmConfig};
        enum SysManagementPage { brandManagement = 0, calibrationCorrection, systemConfig};
        enum SysTestPage { signalTest = 0, realTimeCurve};

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
            //paraConfig
            paraConfig1 = new ParameterConfig.ParameterConfig();
            this.paraConfig1.Location = new System.Drawing.Point(0, 0);
            this.paraConfig1.Name = "statusMonitor2";
            this.paraConfig1.Size = new System.Drawing.Size(1024, 617);
            this.paraConfig1.TabIndex = 2;
            this.navigationPage_paraConfig.Controls.Add(paraConfig1);
            //systemConfig
            systemManagement1 = new SystemManagement.SystemManagement();
            this.systemManagement1.Location = new System.Drawing.Point(0, 0);
            this.systemManagement1.Name = "statusMonitor2";
            this.systemManagement1.Size = new System.Drawing.Size(1024, 617);
            this.systemManagement1.TabIndex = 3;
            this.navigationPage_sysConfig.Controls.Add(systemManagement1);
            //systemTest
            systemTest1 = new SystemTest.SystemTest();
            this.systemTest1.Location = new System.Drawing.Point(0, 0);
            this.systemTest1.Name = "statusMonitor2";
            this.systemTest1.Size = new System.Drawing.Size(1024, 617);
            this.systemTest1.TabIndex = 3;
            this.navigationPage_sysTest.Controls.Add(systemTest1);

        }

        private void _initPages()
        {
            modulePages[0] = navigationPage_statusMonitor;
            modulePages[1] = navigationPage_dataAnalysis;
            modulePages[2] = navigationPage_exportExcel;
            modulePages[3] = navigationPage_paraConfig;
            modulePages[4] = navigationPage_sysConfig;
            modulePages[5] = navigationPage_sysTest;
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

        private void tileBarItem_paraConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_paraConfig);
        }

        private void tileBarItem_sysConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_sysManagement);
        }

        private void tileBarItem_sysTest_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.ShowDropDown(this.tileBarItem_sysTest);
        }

        /**
       **********************************************点击二级子菜单按钮后，子菜单按钮隐藏***********************************************************
       */
        private void tileBar_dataAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        private void tileBar_paraConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        private void tileBar_sysConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tileBar_mainMenu.HideDropDownWindow(false);
        }

        private void tileBar_sysTest_ItemClick(object sender, TileItemEventArgs e)
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

        private void tileBarItem_paraConfig_benchmarkConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.paraConfig];
            this.paraConfig1.selectedFramePage = (int)ParaConfigPage.benchmarkConfig;
        }

        private void tileBarItem_paraConfig_algorithmConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.paraConfig];
            this.paraConfig1.selectedFramePage = (int)ParaConfigPage.algorithmConfig;
        }

        private void tileBarItem_sysManagement_brandManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysConfig];
            this.systemManagement1.selectedFramePage = (int)SysManagementPage.brandManagement;
        }

        private void tileBarItem_sysManagement_calibrationCorrection_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysConfig];
            this.systemManagement1.selectedFramePage = (int)SysManagementPage.calibrationCorrection;
        }

        private void tileBarItem_sysManagement_sysConfig_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysConfig];
            this.systemManagement1.selectedFramePage = (int)SysManagementPage.systemConfig;
        }

        private void tileBarItem_sysTest_signalTest_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysTest];
            this.systemTest1.selectedFramePage = (int)SysTestPage.signalTest;
        }

        private void tileBarItem_sysTest_realTimeCurve_ItemClick(object sender, TileItemEventArgs e)
        {
            this.navigationFrame_mainForm.SelectedPage = modulePages[(int)modulePage.sysTest];
            this.systemTest1.selectedFramePage = (int)SysTestPage.realTimeCurve;
        }

    }
}