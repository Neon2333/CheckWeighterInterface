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
        private int[] selectRowCurrentGridControl = { 0 };      //记录GridControl被选中的行的index
        
        private CommonControl.NumberKeyboard numberKeyboard1;
        
        private int calibrationSectionCount = 1;    //标定段数

        private enum CalibrationMode { singleSectionCalibration = 0, multiSectionCalibration};         
        private CalibrationMode curCalibrationMode = CalibrationMode.singleSectionCalibration;         //标定模式，默认：单段

        private DataTable dtCalibrationDataSensorValAndWeight = new DataTable("calibrationData");      //各端点的传感器值和重量

        private enum ModifySensorValueOrCalibrationWeight { curModifySensorValue = 0, curModifyCalibrationWeight};     
        private ModifySensorValueOrCalibrationWeight curModifyValueType;        //数字小键盘当前修改的是哪个参数     


        public CalibrationCorrection()
        {
            InitializeComponent();
            initCalibrationCorrection();
        }

        private void initCalibrationCorrection()
        {
            //初始化为单段模式
            if(dtCalibrationDataSensorValAndWeight.Columns.Count == 0)
            {
                dtCalibrationDataSensorValAndWeight.Columns.Add("NO", typeof(Int16));
                dtCalibrationDataSensorValAndWeight.Columns.Add("sensorValue", typeof(double));      //传感器值为Int还是double？
                dtCalibrationDataSensorValAndWeight.Columns.Add("calibrationWeight", typeof(double));
            }
            DataRow dr1 = dtCalibrationDataSensorValAndWeight.NewRow();
            dr1["NO"] = 1;
            dr1["sensorValue"] = 0;
            dr1["calibrationWeight"] = 0.0D;
            dtCalibrationDataSensorValAndWeight.Rows.Add(dr1);
            DataRow dr2 = dtCalibrationDataSensorValAndWeight.NewRow();
            dr2["NO"] = 2;
            dr2["sensorValue"] = 0;
            dr2["calibrationWeight"] = 0.0D;
            dtCalibrationDataSensorValAndWeight.Rows.Add(dr2);

            Global.calibrationDataGradient = new double[1];

            this.gridControl_calibrationDataList.DataSource = dtCalibrationDataSensorValAndWeight;

            ChartLineSettings();
        }

        private void ChartLineSettings()
        {
            this.chartControl_calibrationGradient.Series[0].ArgumentScaleType = ScaleType.Numerical;   
            this.chartControl_calibrationGradient.Series[0].ArgumentDataMember = "sensorValue";       
            this.chartControl_calibrationGradient.Series[0].ValueScaleType = ScaleType.Numerical;  
            this.chartControl_calibrationGradient.Series[0].ValueDataMembers.AddRange(new string[] { "calibrationWeight" });
            this.chartControl_calibrationGradient.Series[0].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;                
            this.chartControl_calibrationGradient.Series[0].Label.ResolveOverlappingMode = ResolveOverlappingMode.JustifyAllAroundPoint;	
            this.chartControl_calibrationGradient.Series[0].Label.TextPattern = "({V1:F1}, {V2:F1})";
            ((XYDiagram)(chartControl_calibrationGradient.Diagram)).EnableAxisXScrolling = true;   
            ((XYDiagram)(chartControl_calibrationGradient.Diagram)).EnableAxisYScrolling = true;

        }

        //根据给定的段数，给记录数据的datatable和arr分配空间，默认值为0
        private void allocateCapacityCalibrationData(int countSection)
        {
            clearChartLineCalibrationGradient();

            dtCalibrationDataSensorValAndWeight.Rows.Clear();

            //端点数=段数+1
            for(int i = 0; i < countSection + 1; i++)
            {
                DataRow dr = dtCalibrationDataSensorValAndWeight.NewRow();
                dr["NO"] = i + 1;
                dr["sensorValue"] = 0;
                dr["calibrationWeight"] = 0.0D;
                dtCalibrationDataSensorValAndWeight.Rows.Add(dr);
            }

            Global.calibrationDataGradient = new double[countSection];
        }

        //在DataSource刷新的情况下，保持GridControl选中行不变
        private void keepSelectRowUnchangeWhenDataSourceRefresh()
        {
            if (selectRowCurrentGridControl.Length == 1)
            {
                if (selectRowCurrentGridControl[0] < this.tileView1.DataRowCount)
                    this.tileView1.FocusedRowHandle = selectRowCurrentGridControl[0];     //在DataSource发生改变后，手动修改被选中的row
                else
                {
                    this.tileView1.FocusedRowHandle = 0;
                    selectRowCurrentGridControl[0] = 0;
                }
            }
        }

        //修改模式
        private void toggleSwitch_changeCalibrationMode_Toggled(object sender, EventArgs e)
        {
            if (this.toggleSwitch_changeCalibrationMode.IsOn == false)
            {
                //单段模式
                curCalibrationMode = CalibrationMode.singleSectionCalibration;
                this.labelControl_calibrationMode2.Text = "单段模式";

                this.spinEdit_countSection.Properties.MinValue = 1;
                this.spinEdit_countSection.Value = 1;   //触发spinEdit_countCalibrationSection_ValueChanged，修改calibrationSectionCount
                allocateCapacityCalibrationData(calibrationSectionCount);       //段数修改，则grid行数修改
                this.spinEdit_countSection.Enabled = false; 
                this.simpleButton_confirmCountSection.Enabled = false;
                this.simpleButton_changeSensorValue.Enabled = true;
                this.simpleButton_doCalibration.Enabled = true;
            }
            else
            {
                //多段模式
                curCalibrationMode = CalibrationMode.multiSectionCalibration;
                this.labelControl_calibrationMode2.Text = "多段模式";

                this.spinEdit_countSection.Properties.MinValue = 2;
                this.spinEdit_countSection.Value = 2;       //最少2段
                allocateCapacityCalibrationData(calibrationSectionCount);
                this.spinEdit_countSection.Enabled = true;
                this.simpleButton_confirmCountSection.Enabled = true;
                this.simpleButton_changeSensorValue.Enabled = true;
                this.simpleButton_doCalibration.Enabled = true;
            }
        }
        
        private void spinEdit_countCalibrationSection_ValueChanged(object sender, EventArgs e)
        {
            int spinValTemp = Convert.ToInt32(this.spinEdit_countSection.Value);
            calibrationSectionCount = spinValTemp;
        }

        //确认修改段数
        private void simpleButton_confirmCountSection_Click(object sender, EventArgs e)
        {
            allocateCapacityCalibrationData(calibrationSectionCount);     
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
            int selIndexTemp = selectRowCurrentGridControl[0];
            if(curModifyValueType == ModifySensorValueOrCalibrationWeight.curModifySensorValue)
            {
                dtCalibrationDataSensorValAndWeight.Rows[selIndexTemp]["sensorValue"] = this.numberKeyboard1.result;
                clearChartLineCalibrationGradient();
            }
            else if(curModifyValueType == ModifySensorValueOrCalibrationWeight.curModifyCalibrationWeight)
            {
                dtCalibrationDataSensorValAndWeight.Rows[selIndexTemp]["calibrationWeight"] = this.numberKeyboard1.result;
                clearChartLineCalibrationGradient();
            }
        }

        private void gridControl_calibrationDataList_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.gridControl_calibrationDataList.DataSource).Rows.Count > 0)
                selectRowCurrentGridControl = this.tileView1.GetSelectedRows();  //手动记录被按下按钮
            if (selectRowCurrentGridControl.Length > 1)
            {
                MessageBox.Show("当前选中超过一行");
            }
        }

        //标定
        private void simpleButton_doCalibration_Click(object sender, EventArgs e)
        {
            double delta1 = 0.0D;
            double delta2 = 0.0D;
            for(int i = 0; i < calibrationSectionCount; i++)
            {
                delta1 = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i + 1]["calibrationWeight"]) - Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["calibrationWeight"]);
                delta2 = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i + 1]["sensorValue"]) - Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]);
                Global.calibrationDataGradient[i] = delta1 / delta2;
            }

            refreshChartLineCalibrationGradient();  
        }

        //斜率不显示
        private void clearChartLineCalibrationGradient()
        {
            this.chartControl_calibrationGradient.Series[0].DataSource = null;
        }

        //显示新的斜率点
        private void refreshChartLineCalibrationGradient()
        {
            this.chartControl_calibrationGradient.Series[0].DataSource = dtCalibrationDataSensorValAndWeight;

            double sensorValueMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["sensorValue"]);
            double calibrationWeightMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["calibrationWeight"]);
            double sensorValueMax = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["sensorValue"]);
            double calibrationWeightMax = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[0]["calibrationWeight"]);

            for (int i = 1; i < calibrationSectionCount + 1; i++)
            {
                if(Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]) < sensorValueMin)
                {
                    sensorValueMin = Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]);
                }
                else if(Convert.ToDouble(dtCalibrationDataSensorValAndWeight.Rows[i]["sensorValue"]) > sensorValueMax)
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




    }
}
