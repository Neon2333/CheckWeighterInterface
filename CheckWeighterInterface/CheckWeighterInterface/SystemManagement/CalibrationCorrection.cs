using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckWeighterInterface.SystemManagement
{
    public partial class CalibrationCorrection : DevExpress.XtraEditors.XtraUserControl
    {
        /*只有dtCalibrationDataSensorValAndWeight和dtCalibrationGradient是绑定页面控件的数据源*/
        private CommonControl.NumberKeyboard numberKeyboard1;
        
        //标定模式
        private enum CalibrationMode { singleSectionCalibration = 0, multiSectionCalibration};         
        private CalibrationMode curCalibrationMode = CalibrationMode.singleSectionCalibration;      //当前模式

        //上次关闭时是否被标定过
        private enum HasBeenCalibrated { HasNotBeenCalibrated = 0, hasBeenSingleCalibrated, hasBeenMultiCalibrated, hasBeenBothCalibrated};
        private HasBeenCalibrated hasBeenCalibrated;                //记录之前是否被标定过
        private int countSectionBeenMultiCalibrated;                //记录之前被标定的段数

        //当前标定段数
        private int curCalibrationSectionCount = 1;    

        private DataTable dtCalibrationDataSensorValAndWeight = new DataTable("calibrationData");      //各端点的传感器值和重量

        //数字小键盘当前修改的是哪个参数     
        private enum ModifySensorValueOrCalibrationWeight { curModifySensorValue = 0, curModifyCalibrationWeight};     
        private ModifySensorValueOrCalibrationWeight curModifyValueType;

        DataTable dtCalibrationModeAndCountSectionQueryMySQL = new DataTable("calibrationModeAndCountSectionQueryMySQL");   //记录上次标定模式、段数、是否被标定过
        DataTable dtSingleModeCalibrationDataQueryMySQL = new DataTable("singleModeCalibrationDataQueryMySQL");     //记录从MySQL中读取的单段模式标定数据
        DataTable dtSingleModeGradientQueryMySQL = new DataTable("singleModeGradientQueryMySQL");                   //记录从MySQL中读取的单段模式斜率
        DataTable dtMultiModeCalibrationDatQueryMySQL = new DataTable("multiModeCalibrationDataQueryMySQL");       //记录从MySQL中读取的多段模式标定数据
        DataTable dtMultiModeGradientQueryMySQL = new DataTable("multiModeGradientQueryMySQL");                     //记录从MySQL中读取的多段模式斜率

        public CalibrationCorrection()
        {
            InitializeComponent();
            initCalibrationCorrection();
        }

        //初始化标定页面
        //显示模式记忆上次关闭软件时的模式
        //从MySQL分别读取单段标定数据表、多段数据表，若有数据则显示作为3个dt值并在grid中显示，供用户修改。若没有数据，则在grid中显示NaN
        private void initCalibrationCorrection()
        {
            initDt();
            queryHasBeenCalibratedAndDataGradient();

            this.gridControl_calibrationDataList.DataSource = dtCalibrationDataSensorValAndWeight;
            ChartLineSettings();
            this.chartControl_calibrationGradient.Series[0].DataSource = dtCalibrationDataSensorValAndWeight;
            this.gridControl_calibrationGradient.DataSource = Global.dtCalibrationGradient;
        }

        //初始化所有的datatable
        private void initDt()
        {
            if (dtCalibrationDataSensorValAndWeight.Columns.Count == 0)
            {
                dtCalibrationDataSensorValAndWeight.Columns.Add("NO", typeof(Int16));
                dtCalibrationDataSensorValAndWeight.Columns.Add("sensorValue", typeof(double));      //传感器值为Int还是double？
                dtCalibrationDataSensorValAndWeight.Columns.Add("calibrationWeight", typeof(double));
            }

            //Global.calibrationDataGradient = new double[1];
            if (Global.dtCalibrationGradient.Columns.Count == 0)
            {
                Global.dtCalibrationGradient.Columns.Add("NO", typeof(String));
                Global.dtCalibrationGradient.Columns.Add("gradient", typeof(double));      //传感器值为Int还是double？
            }

            if(dtCalibrationModeAndCountSectionQueryMySQL.Columns.Count == 0)
            {
                dtCalibrationModeAndCountSectionQueryMySQL.Columns.Add("hasBeenCalibrated", typeof(Int32));   //0表示未标定过，1表示单段标定过，2表示多段标定过，3表示两种模式都标定过
                dtCalibrationModeAndCountSectionQueryMySQL.Columns.Add("countSection", typeof(Int32));
            }

            if (dtSingleModeCalibrationDataQueryMySQL.Columns.Count == 0)
            {
                dtSingleModeCalibrationDataQueryMySQL.Columns.Add("NO", typeof(Int16));
                dtSingleModeCalibrationDataQueryMySQL.Columns.Add("sensorValue", typeof(double));
                dtSingleModeCalibrationDataQueryMySQL.Columns.Add("weight", typeof(double));
            }

            if (dtSingleModeGradientQueryMySQL.Columns.Count == 0)
            {
                dtSingleModeGradientQueryMySQL.Columns.Add("section", typeof(String));
                dtSingleModeGradientQueryMySQL.Columns.Add("gradient", typeof(double));
            }

            if (dtMultiModeCalibrationDatQueryMySQL.Columns.Count == 0)
            {
                dtMultiModeCalibrationDatQueryMySQL.Columns.Add("NO", typeof(Int16));
                dtMultiModeCalibrationDatQueryMySQL.Columns.Add("sensorValue", typeof(double));
                dtMultiModeCalibrationDatQueryMySQL.Columns.Add("weight", typeof(double));
            }

            if (dtMultiModeGradientQueryMySQL.Columns.Count == 0)
            {
                dtMultiModeGradientQueryMySQL.Columns.Add("section", typeof(String));
                dtMultiModeGradientQueryMySQL.Columns.Add("gradient", typeof(double));
            }
        }

        //折线图参数设定
        private void ChartLineSettings()
        {
            this.chartControl_calibrationGradient.Series[0].ArgumentScaleType = ScaleType.Numerical;   
            this.chartControl_calibrationGradient.Series[0].ArgumentDataMember = "sensorValue";       
            this.chartControl_calibrationGradient.Series[0].ValueScaleType = ScaleType.Numerical;  
            this.chartControl_calibrationGradient.Series[0].ValueDataMembers.AddRange(new string[] { "calibrationWeight" });
            this.chartControl_calibrationGradient.Series[0].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;                
            this.chartControl_calibrationGradient.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAllAroundPoint;
            this.chartControl_calibrationGradient.Series[0].Label.TextPattern = "({A},{V:F3})";
            ((XYDiagram)(chartControl_calibrationGradient.Diagram)).EnableAxisXScrolling = true;   
            ((XYDiagram)(chartControl_calibrationGradient.Diagram)).EnableAxisYScrolling = true;
        }

        //从MySQL中查询是否被标定过、标定数据、斜率等数据并写入3个dt
        private void queryHasBeenCalibratedAndDataGradient()
        {
            //从MySQL读取模式、段数、是否被标定过
            string cmdQueryCalibrationMode = "SELECT * FROM mode_count_section;";
            
            Global.mysqlHelper1._queryTableMySQL(cmdQueryCalibrationMode, ref dtCalibrationModeAndCountSectionQueryMySQL);
            hasBeenCalibrated = (HasBeenCalibrated)Convert.ToInt32(dtCalibrationModeAndCountSectionQueryMySQL.Rows[0]["hasBeenCalibrated"]);
            countSectionBeenMultiCalibrated = Convert.ToInt32(dtCalibrationModeAndCountSectionQueryMySQL.Rows[0]["countSection"]);

            if(hasBeenCalibrated == HasBeenCalibrated.hasBeenMultiCalibrated)   //只有多段已标定时显示多段，其他情况均显示单段
            {
                curCalibrationMode = CalibrationMode.multiSectionCalibration;
            }


            //从MySQL读取标定数据
            string cmdQuerySingleCalibrationData = "SELECT * FROM single_mode_calibration_data;";

            string cmdQuerySingleModeGradient = "SELECT * FROM single_mode_calibration_data;";

            string cmdQueryMultiCalibrationData = "SELECT * FROM multi_mode_calibration_data;";

            string cmdQueryMultiModeGradient = "SELECT * FROM multi_mode_calibration_data;";

            string[] colsDtCalibrationDataSensorValAndWeight = { "NO", "sensorValue", "calibrationWeight" };
            string[] colsDtCalibrationGradient = { "NO", "gradient" };
            if (curCalibrationMode == CalibrationMode.singleSectionCalibration)
            {
                //初始化为单段模式
                switchCalibrationMode(CalibrationMode.singleSectionCalibration, 1);

                if (hasBeenCalibrated == HasBeenCalibrated.HasNotBeenCalibrated)
                {
                    object[] paras1 = { 1, Double.NaN, Double.NaN };
                    object[] paras2 = { 2, Double.NaN, Double.NaN };
                    //Global.calibrationDataGradient[i] = delta1 / delta2;
                    Global.dtRowAdd(ref dtCalibrationDataSensorValAndWeight, 3, colsDtCalibrationDataSensorValAndWeight, paras1);
                    Global.dtRowAdd(ref dtCalibrationDataSensorValAndWeight, 3, colsDtCalibrationDataSensorValAndWeight, paras2);

                    object[] parasDtCalibrationGradient1 = { "1-2", Double.NaN };
                    Global.dtRowAdd(ref Global.dtCalibrationGradient, 2, colsDtCalibrationGradient, parasDtCalibrationGradient1);
                }
                else if (hasBeenCalibrated == HasBeenCalibrated.hasBeenSingleCalibrated)
                {
                    Global.mysqlHelper1._queryTableMySQL(cmdQuerySingleCalibrationData, ref dtSingleModeCalibrationDataQueryMySQL);
                    Global.mysqlHelper1._queryTableMySQL(cmdQuerySingleModeGradient, ref dtSingleModeGradientQueryMySQL);

                    allocateCapacityCalibrationData(1);

                    for (int i = 0; i < dtSingleModeCalibrationDataQueryMySQL.Rows.Count; i++)
                    {
                        dtCalibrationDataSensorValAndWeight.Rows[i]["NO"] = dtSingleModeCalibrationDataQueryMySQL.Rows[i]["NO"];
                        dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"] = dtSingleModeCalibrationDataQueryMySQL.Rows[i]["sensorValue"];
                        dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"] = dtSingleModeCalibrationDataQueryMySQL.Rows[i]["calibrationWeight"];
                    }

                    for (int i = 0; i < dtSingleModeGradientQueryMySQL.Rows.Count; i++)
                    {
                        Global.dtCalibrationGradient.Rows[i]["NO"] = dtSingleModeGradientQueryMySQL.Rows[i]["NO"];
                        Global.dtCalibrationGradient.Rows[i]["gradient"] = dtSingleModeGradientQueryMySQL.Rows[i]["gradient"];
                    }

                }
            }
            else if (curCalibrationMode == CalibrationMode.multiSectionCalibration)
            {
                //初始化为多段模式
                switchCalibrationMode(CalibrationMode.multiSectionCalibration, countSectionBeenMultiCalibrated);

                if (hasBeenCalibrated == HasBeenCalibrated.HasNotBeenCalibrated)
                {
                    object[] parasDtCalibrationDataSensorValAndWeight1 = { 1, Double.NaN, Double.NaN };
                    object[] parasDtCalibrationDataSensorValAndWeight2 = { 2, Double.NaN, Double.NaN };
                    object[] parasDtCalibrationDataSensorValAndWeight3 = { 3, Double.NaN, Double.NaN };

                    //Global.calibrationDataGradient[i] = delta1 / delta2;
                    Global.dtRowAdd(ref dtCalibrationDataSensorValAndWeight, 3, colsDtCalibrationDataSensorValAndWeight, parasDtCalibrationDataSensorValAndWeight1);
                    Global.dtRowAdd(ref dtCalibrationDataSensorValAndWeight, 3, colsDtCalibrationDataSensorValAndWeight, parasDtCalibrationDataSensorValAndWeight2);
                    Global.dtRowAdd(ref dtCalibrationDataSensorValAndWeight, 3, colsDtCalibrationDataSensorValAndWeight, parasDtCalibrationDataSensorValAndWeight3);

                    object[] parasDtCalibrationGradient1 = { 1, "1-2", Double.NaN };
                    object[] parasDtCalibrationGradient2 = { 2, "2-3", Double.NaN };

                    Global.dtRowAdd(ref Global.dtCalibrationGradient, 2, colsDtCalibrationGradient, parasDtCalibrationGradient1);
                    Global.dtRowAdd(ref Global.dtCalibrationGradient, 2, colsDtCalibrationGradient, parasDtCalibrationGradient2);
                }
                else if (hasBeenCalibrated == HasBeenCalibrated.hasBeenMultiCalibrated)
                {
                    Global.mysqlHelper1._queryTableMySQL(cmdQueryMultiCalibrationData, ref dtMultiModeCalibrationDatQueryMySQL);
                    Global.mysqlHelper1._queryTableMySQL(cmdQueryMultiModeGradient, ref dtMultiModeGradientQueryMySQL);

                    allocateCapacityCalibrationData(countSectionBeenMultiCalibrated);

                    for (int i = 0; i < dtMultiModeCalibrationDatQueryMySQL.Rows.Count; i++)
                    {
                        dtCalibrationDataSensorValAndWeight.Rows[i]["NO"] = dtMultiModeCalibrationDatQueryMySQL.Rows[i]["NO"];
                        dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"] = dtMultiModeCalibrationDatQueryMySQL.Rows[i]["sensorValue"];
                        dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"] = dtMultiModeCalibrationDatQueryMySQL.Rows[i]["calibrationWeight"];
                    }

                    for (int i = 0; i < dtMultiModeGradientQueryMySQL.Rows.Count; i++)
                    {
                        Global.dtCalibrationGradient.Rows[i]["NO"] = dtMultiModeGradientQueryMySQL.Rows[i]["NO"];
                        Global.dtCalibrationGradient.Rows[i]["gradient"] = dtMultiModeGradientQueryMySQL.Rows[i]["gradient"];
                    }

                }
            }
        }

        //按照给定模式、段数修改模式
        private void switchCalibrationMode(CalibrationMode mode, int countSection)
        {
            if(mode == CalibrationMode.singleSectionCalibration)
            {
                //单段模式
                this.labelControl_calibrationMode2.Text = "单段模式";
                curCalibrationMode = CalibrationMode.singleSectionCalibration;
                curCalibrationSectionCount = 1;
                this.spinEdit_countSection.Properties.MinValue = 1;
                this.spinEdit_countSection.Value = 1;
            }
            else if(mode == CalibrationMode.multiSectionCalibration)
            {
                //多段模式
                this.labelControl_calibrationMode2.Text = "多段模式";
                curCalibrationMode = CalibrationMode.multiSectionCalibration;
                curCalibrationSectionCount = countSection;
                this.spinEdit_countSection.Properties.MinValue = 2;
                if (countSection < 2)
                    return;
                this.spinEdit_countSection.Value = countSection;
            }

            saveHasBeenCalibrated();

            this.spinEdit_countSection.Enabled = false;
            
            allocateCapacityCalibrationData(curCalibrationSectionCount);       //段数修改，清空datatable重新分配空间

            setButtonEnableSpinValueCompareSectionCount(true);
        }

        //修改模式
        private void toggleSwitch_changeCalibrationMode_Toggled(object sender, EventArgs e)
        {
            if (this.toggleSwitch_changeCalibrationMode.IsOn == false)
            {
                //单段模式
                switchCalibrationMode(CalibrationMode.singleSectionCalibration, 1);
            }
            else
            {
                //多段模式
                switchCalibrationMode(CalibrationMode.multiSectionCalibration, 2);
            }
        }

        //模式发生改变时，保存到MySQL
        private void saveHasBeenCalibrated()
        {
            string cmdUpdateModeAndCountSection = String.Empty;
            if (curCalibrationMode == CalibrationMode.multiSectionCalibration)
            {
                //保存被标定模式和段数
                cmdUpdateModeAndCountSection = "UPDATE mode_count_section SET `hasBeenCalibrated`=" + ((int)hasBeenCalibrated).ToString() + ", `countSection`=" + curCalibrationSectionCount.ToString() + ";";
            }
            else if(curCalibrationMode == CalibrationMode.singleSectionCalibration)
            {
                cmdUpdateModeAndCountSection = "UPDATE mode_count_section SET `hasBeenCalibrated`=" + ((int)hasBeenCalibrated).ToString() + ";";
            }

            Global.mysqlHelper1._updateMySQL(cmdUpdateModeAndCountSection);
        }

        //根据给定的段数，给记录数据的datatable和arr清空重新分配空间，默认值为NaN
        private void allocateCapacityCalibrationData(int countSection)
        {
            clearChartLineCalibrationGradient();

            clearGridCalibrationGradient();

            dtCalibrationDataSensorValAndWeight.Rows.Clear();
            //Global.dtCalibrationGradient.Rows.Clear();

            //端点数=段数+1
            for(int i = 0; i < countSection + 1; i++)
            {
                DataRow dr = dtCalibrationDataSensorValAndWeight.NewRow();
                dr["NO"] = i + 1;
                dr["sensorValue"] = Double.NaN;
                dr["calibrationWeight"] = Double.NaN;
                dtCalibrationDataSensorValAndWeight.Rows.Add(dr);
            }

            //Global.calibrationDataGradient = new double[countSection];
            for(int i = 0; i < countSection; i++)
            {
                DataRow dr = Global.dtCalibrationGradient.NewRow();
                dr["NO"] = (i + 1).ToString() + "-" + (i + 2).ToString();
                dr["gradient"] = Double.NaN;
                Global.dtCalibrationGradient.Rows.Add(dr);
            }
        }

        //计算斜率
        private void calcGradient()
        {
            Global.dtCalibrationGradient.Rows.Clear();
            double delta1 = 0.0D;
            double delta2 = 0.0D;
            for(int i = 0; i < curCalibrationSectionCount; i++)
            {
                delta1 = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i + 1]["calibrationWeight"]) - Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"]);
                delta2 = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i + 1]["sensorValue"]) - Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]);
                DataRow dr = Global.dtCalibrationGradient.NewRow();
                dr["NO"] = (i + 1).ToString() + "-" + (i + 2).ToString();
                dr["gradient"] = delta1 / delta2;
                Global.dtCalibrationGradient.Rows.Add(dr);
            }

            refreshChartLineCalibrationGradient();
        }

        //spinEdit.Value修改时，判断spinEdit值和实际段数是否相等的按钮使能逻辑
        private void setButtonEnableSpinValueCompareSectionCount(bool spinValueEqualSectionCount)
        {
            if (!spinValueEqualSectionCount)
            {
                this.simpleButton_confirmCountSection.Enabled = true;
                this.simpleButton_changeSensorValue.Enabled = false;
                this.simpleButton_changeCalibrationWeight.Enabled = false;
                this.simpleButton_doCalibration.Enabled = false;
            }
            else
            {
                this.simpleButton_confirmCountSection.Enabled = false;
                this.simpleButton_changeSensorValue.Enabled = true;
                this.simpleButton_changeCalibrationWeight.Enabled = true;
                this.simpleButton_doCalibration.Enabled = true;
            }
        }

        //标定点折线图不显示
        private void clearChartLineCalibrationGradient()
        {
            this.chartControl_calibrationGradient.Series[0].DataSource = null;
        }

        //刷新标定点折线图，显示新的斜率点
        private void refreshChartLineCalibrationGradient()
        {
            this.chartControl_calibrationGradient.Series[0].DataSource = dtCalibrationDataSensorValAndWeight;

            double sensorValueMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["sensorValue"]);
            double calibrationWeightMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["calibrationWeight"]);
            double sensorValueMax = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["sensorValue"]);
            double calibrationWeightMax = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["calibrationWeight"]);

            for (int i = 1; i < curCalibrationSectionCount + 1; i++)
            {
                if (Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]) < sensorValueMin)
                {
                    sensorValueMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]);
                }
                else if (Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]) > sensorValueMax)
                {
                    sensorValueMax = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]);
                }

                if (Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"]) < calibrationWeightMin)
                {
                    calibrationWeightMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"]);
                }
                else if (Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"]) > calibrationWeightMax)
                {
                    calibrationWeightMax = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"]);
                }
            }


            double deltaX = sensorValueMax - sensorValueMin;
            double deltaY = calibrationWeightMax - calibrationWeightMin;
            double k = 0.2;
            ((XYDiagram)(chartControl_calibrationGradient.Diagram)).AxisX.WholeRange.SetMinMaxValues(sensorValueMin - k * deltaX, sensorValueMax + k * deltaX);
            ((XYDiagram)(chartControl_calibrationGradient.Diagram)).AxisY.WholeRange.SetMinMaxValues(calibrationWeightMin - k * deltaY, calibrationWeightMax + k * deltaY);
        }

        //斜率列表不显示
        private void clearGridCalibrationGradient()
        {
            //this.gridControl_calibrationGradient.DataSource = null;
            Global.dtCalibrationGradient.Rows.Clear();
        }

        private void spinEdit_countCalibrationSection_ValueChanged(object sender, EventArgs e)
        {
            if (curCalibrationSectionCount != Convert.ToInt32(this.spinEdit_countSection.Value))
            {
                setButtonEnableSpinValueCompareSectionCount(false);
            }
            else
            {
                setButtonEnableSpinValueCompareSectionCount(true);
            }

        }

        //确认修改段数
        private void simpleButton_confirmCountSection_Click(object sender, EventArgs e)
        {
            curCalibrationSectionCount = Convert.ToInt32(this.spinEdit_countSection.Value);
            allocateCapacityCalibrationData(curCalibrationSectionCount);

            setButtonEnableSpinValueCompareSectionCount(true);
        }

        //修改标定值
        private void simpleButton_changeSensorValue_Click(object sender, EventArgs e)
        {
            if (dtCalibrationDataSensorValAndWeight.Rows.Count != 0)
            {
                curModifyValueType = ModifySensorValueOrCalibrationWeight.curModifySensorValue;
                createNumberKeyboard("输入传感器值", -999999.0D, 999999.0D);
                this.numberKeyboard1.Visible = true;
            }
        }

        //修改重量
        private void simpleButton_changeCalibrationWeight_Click(object sender, EventArgs e)
        {
            if (dtCalibrationDataSensorValAndWeight.Rows.Count != 0)
            {
                curModifyValueType = ModifySensorValueOrCalibrationWeight.curModifyCalibrationWeight;
                createNumberKeyboard("输入传感器值", -999999.0D, 999999.0D);
                this.numberKeyboard1.Visible = true;
            }

        }

        //创建数字小键盘对象
        private void createNumberKeyboard(string title, double min, double max)
        {
            if (this.numberKeyboard1 != null)
            {
                this.numberKeyboard1.Visible = false;
            }
            this.numberKeyboard1 = new CommonControl.NumberKeyboard(min, max);
            this.numberKeyboard1.Appearance.BackColor = System.Drawing.Color.White;
            this.numberKeyboard1.Appearance.Options.UseBackColor = true;
            this.numberKeyboard1.Location = new System.Drawing.Point(310, 3);
            this.numberKeyboard1.Name = "numberKeyboard1";
            this.numberKeyboard1.Size = new System.Drawing.Size(350, 600);
            this.numberKeyboard1.TabIndex = 28;
            this.numberKeyboard1.title = title;
            this.numberKeyboard1.outOfRangeType = CommonControl.NumberKeyboard.OutOfRangeType.minMaxIllegal;    //设定输入值取最值非法
            this.Controls.Add(this.numberKeyboard1);
            this.numberKeyboard1.BringToFront();
            this.numberKeyboard1.Visible = false;
            this.numberKeyboard1.NumberKeyboardEnterClicked += new CheckWeighterInterface.CommonControl.NumberKeyboard.SimpleButtonEnterClickHanlder(this.numberKeyboard1_NumberKeyboardEnterClicked);
        }

        //小键盘Enter响应
        private void numberKeyboard1_NumberKeyboardEnterClicked(object sender, EventArgs e)
        {
            //int selIndexTemp = selectRowCurrentGridControl[0];
            int selIndexTemp = this.tileView1.FocusedRowHandle;
            if (curModifyValueType == ModifySensorValueOrCalibrationWeight.curModifySensorValue)
            {
                dtCalibrationDataSensorValAndWeight.Rows[selIndexTemp]["sensorValue"] = this.numberKeyboard1.result;    //从小键盘获取值作为传感器值进行修改
                calcGradient();
            }
            else if(curModifyValueType == ModifySensorValueOrCalibrationWeight.curModifyCalibrationWeight)
            {
                dtCalibrationDataSensorValAndWeight.Rows[selIndexTemp]["calibrationWeight"] = this.numberKeyboard1.result;
                calcGradient();
            }
        }

        //标定。从下位机获取1个传感器值，将其存入dt，并计算斜率
        private void simpleButton_doCalibration_Click(object sender, EventArgs e)
        {
            int selIndexTemp = this.tileView1.FocusedRowHandle;
            dtCalibrationDataSensorValAndWeight.Rows[selIndexTemp]["sensorValue"] = Global.curSensorValue;
            calcGradient();
        }

        //将3个datatable中内容写入MySQL，修改hasBeenCalibrated标志
        private void simpleButton_saveCalibrationData_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Global.dtCalibrationGradient.Rows.Count; i++)
            {
                if (Double.IsNaN(Convert.ToDouble(Global.dtCalibrationGradient.Rows[i]["gradient"])))
                {
                    MessageBox.Show("标定数据无效");
                    return;
                }
            }

            string cmdInsertSensorValueAndWeight = String.Empty;
            string cmdInsertCalibrationGradient = String.Empty;
            int NO = 0;
            string sensor_value = String.Empty;
            string calibrationWeight = String.Empty;
            string section = String.Empty;
            string gradient = String.Empty;

            if (curCalibrationMode == CalibrationMode.singleSectionCalibration)
            {
                //保存单段数据
                cmdInsertSensorValueAndWeight = "INSERT INTO single_mode_sensor_value_weight (`NO`, `sensor_value`, `calibrationWeight`) VALUES (1, " + dtCalibrationDataSensorValAndWeight.Rows[0]["sensorValue"].ToString() + ", " + dtCalibrationDataSensorValAndWeight.Rows[0]["calibrationWeight"].ToString() + ");";
                Global.mysqlHelper1._insertMySQL(cmdInsertSensorValueAndWeight);

                cmdInsertSensorValueAndWeight = "INSERT INTO single_mode_sensor_value_weight (`NO`, `sensor_value`, `calibrationWeight`) VALUES (2, " + dtCalibrationDataSensorValAndWeight.Rows[0]["sensorValue"].ToString() + ", " + dtCalibrationDataSensorValAndWeight.Rows[0]["calibrationWeight"].ToString() + ");";
                Global.mysqlHelper1._insertMySQL(cmdInsertSensorValueAndWeight);

                cmdInsertCalibrationGradient =  "INSERT INTO single_mode_gradient (`NO`,  `section`, `gradient`) VALUES (1, '1-2', " + Global.dtCalibrationGradient.Rows[0]["gradient"].ToString() + ");";
                Global.mysqlHelper1._insertMySQL(cmdInsertCalibrationGradient);

                switch (hasBeenCalibrated)
                {
                    case HasBeenCalibrated.HasNotBeenCalibrated:
                        hasBeenCalibrated = HasBeenCalibrated.hasBeenSingleCalibrated;
                        break;
                    case HasBeenCalibrated.hasBeenSingleCalibrated:
                        break;
                    case HasBeenCalibrated.hasBeenMultiCalibrated:
                        hasBeenCalibrated = HasBeenCalibrated.hasBeenBothCalibrated;
                        break;
                    case HasBeenCalibrated.hasBeenBothCalibrated:
                        break;
                }
            }
            else
            {
                //保存多段数据
                for (int i = 0; i < dtCalibrationDataSensorValAndWeight.Rows.Count; i++)
                {
                    NO = i + 1;
                    sensor_value = dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"].ToString();
                    calibrationWeight = dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"].ToString();
                    cmdInsertSensorValueAndWeight = "INSERT INTO single_mode_sensor_value_weight (`NO`, `sensor_value`, `calibrationWeight`) VALUES (" + NO.ToString() + ", " + sensor_value + ", " + calibrationWeight + ");";
                    Global.mysqlHelper1._insertMySQL(cmdInsertSensorValueAndWeight);


                    switch (hasBeenCalibrated)
                    {
                        case HasBeenCalibrated.HasNotBeenCalibrated:
                            hasBeenCalibrated = HasBeenCalibrated.hasBeenSingleCalibrated;
                            break;
                        case HasBeenCalibrated.hasBeenSingleCalibrated:
                            break;
                        case HasBeenCalibrated.hasBeenMultiCalibrated:
                            hasBeenCalibrated = HasBeenCalibrated.hasBeenBothCalibrated;
                            break;
                        case HasBeenCalibrated.hasBeenBothCalibrated:
                            break;
                    }

                }

                for (int i = 0;i< Global.dtCalibrationGradient.Rows.Count; i++)
                {
                    NO = i + 1;
                    section = NO.ToString() + "-" + (NO + 1).ToString();
                    gradient = Global.dtCalibrationGradient.Rows[i]["gradient"].ToString();
                    cmdInsertCalibrationGradient = "INSERT INTO multi_mode_gradient (`NO`,  `section`, `gradient`) VALUES (" + NO.ToString() + ", '" + section + "', " + gradient + ");"; 
                    Global.mysqlHelper1._insertMySQL(cmdInsertCalibrationGradient);

                }
            }

            saveHasBeenCalibrated();    //保存模式
        }

        //丢弃datatable在数据
        private void simpleButton_cancelCalibrationData_Click(object sender, EventArgs e)
        {

        }


        

        
    }
}
