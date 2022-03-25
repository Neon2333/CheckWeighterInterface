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

namespace CheckWeighterInterface.SystemTest
{
    public partial class RealTimeCurve : DevExpress.XtraEditors.XtraUserControl
    {
        private DataTable dtSensorRealTimeData = new DataTable("dtSensorRealTimeData");

        public RealTimeCurve()
        {
            InitializeComponent();
            initRealTimeCurve();
        }

        private void reInitRealTimeCurve()
        {

        }

        private void initRealTimeCurve()
        {
            initDataTable();
            bindLineData();
        }

        private void initDataTable()
        {
            if (dtSensorRealTimeData.Columns.Count == 0)
            {
                dtSensorRealTimeData.Columns.Add("countSensorRealTimeData", typeof(Int32));        //称重计数
                dtSensorRealTimeData.Columns.Add("sensorRealTimeData", typeof(double));        //当前重量
            }
        }

        //刷新当前页面
        private void refreshRealTimeCurve()
        {
            updateSensorRealTimeData();
        }

        private void bindLineData()
        {
            this.chartControl_weighterSensorRealTimeData.Series[0].DataSource = dtSensorRealTimeData;      //绑定Datatable
            this.chartControl_weighterSensorRealTimeData.Series[0].ArgumentScaleType = ScaleType.Numerical;   //设定Argument的类型
            this.chartControl_weighterSensorRealTimeData.Series[0].ArgumentDataMember = "countSensorRealTimeData";       //设定Argument的字段名
            this.chartControl_weighterSensorRealTimeData.Series[0].ValueScaleType = ScaleType.Numerical;  //设定Value的类型
            this.chartControl_weighterSensorRealTimeData.Series[0].ValueDataMembers.AddRange(new string[] { "sensorRealTimeData" });
            ((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).EnableAxisXScrolling = true;   //横轴滚动条使能
            ((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).EnableAxisYScrolling = true;   //纵轴滚动条使能


        }

        private void updateSensorRealTimeData()
        {
                DataRow drCurWeight = dtSensorRealTimeData.NewRow();
                drCurWeight["countSensorRealTimeData"] = Global.curStatus.countDetection;
                drCurWeight["sensorRealTimeData"] = Global.curStatus.curWeight;
                dtSensorRealTimeData.Rows.Add(drCurWeight);
        }

        private void updatePeakValleyAvg()
        {
            double sum = 0.0D;
            int minIndex = 0;
            int maxIndex = dtSensorRealTimeData.Rows.Count - 1;

            for(int i = 0; i < dtSensorRealTimeData.Rows.Count; i++)
            {

            }
        }

        private void timer_getDataOnceFromSensor_Tick(object sender, EventArgs e)
        {
            refreshRealTimeCurve();
        }

        private void simpleButton_modifyAxisRange_Click(object sender, EventArgs e)
        {
            int dataLen = this.dtSensorRealTimeData.Rows.Count;
            double xMin = this.textEdit_setXMinVal.Text == "" ? (double)(((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.VisualRange.MinValue) : Convert.ToDouble(this.textEdit_setXMinVal.Text);
            double xMax = this.textEdit_setXMaxVal.Text == "" ? (double)(((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.VisualRange.MaxValue) : Convert.ToDouble(this.textEdit_setXMaxVal.Text);
            double yMin = this.textEdit_setYMinVal.Text == "" ? (double)(((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.VisualRange.MinValue) : Convert.ToDouble(this.textEdit_setYMinVal.Text);
            double yMax = this.textEdit_setYMaxVal.Text == "" ? (double)(((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.VisualRange.MaxValue) : Convert.ToDouble(this.textEdit_setYMaxVal.Text);

            if (xMin < 0 || xMax <= xMin || yMin <0 || yMax <= yMin)
            {
                MessageBox.Show("请输入合法的范围");
                return;
            }

            ((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.VisualRange.SetMinMaxValues(xMin, xMax);
            ((DevExpress.XtraCharts.XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.VisualRange.SetMinMaxValues(yMin, yMax);

        }


    }
}
