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
            if (Global.dtSensorRealTimeData.Columns.Count == 0)
            {
                Global.dtSensorRealTimeData.Columns.Add("countSensorRealTimeData", typeof(Int32));        //称重计数
                Global.dtSensorRealTimeData.Columns.Add("sensorRealTimeData", typeof(double));        //当前重量
            }
        }
        private void refreshRealTimeCurve()
        {
            if (Global.enableReFreshRealTimeCurve)
            {
                updateSensorRealTimeData();
                updatePeakValleyAvg();
            }

        }

        private void bindLineData()
        {
            this.chartControl_weighterSensorRealTimeData.Series[0].DataSource = Global.dtSensorRealTimeData;      //绑定Datatable
            this.chartControl_weighterSensorRealTimeData.Series[0].ArgumentScaleType = ScaleType.Numerical;   //设定Argument的类型
            this.chartControl_weighterSensorRealTimeData.Series[0].ArgumentDataMember = "countSensorRealTimeData";       //设定Argument的字段名
            this.chartControl_weighterSensorRealTimeData.Series[0].ValueScaleType = ScaleType.Numerical;  //设定Value的类型
            this.chartControl_weighterSensorRealTimeData.Series[0].ValueDataMembers.AddRange(new string[] { "sensorRealTimeData" });
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).EnableAxisXScrolling = true;   //横轴滚动条使能
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).EnableAxisYScrolling = true;   //纵轴滚动条使能
        }

        //刷新当前页面
        private void updateSensorRealTimeData()
        {
            DataRow drCurWeight = Global.dtSensorRealTimeData.NewRow();
            drCurWeight["countSensorRealTimeData"] = Global.curStatus.countDetection;
            drCurWeight["sensorRealTimeData"] = Global.curStatus.curWeight;
            Global.dtSensorRealTimeData.Rows.Add(drCurWeight);
        }

        //刷新峰值、谷值、均值
        private void updatePeakValleyAvg()
        {
            double sum = 0.0D;
            int minIndex = 0;
            int maxIndex = Global.dtSensorRealTimeData.Rows.Count - 1;

            for (int i = 0; i < Global.dtSensorRealTimeData.Rows.Count; i++)
            {
                double tempWeight = Convert.ToDouble(Global.dtSensorRealTimeData.Rows[i]["sensorRealTimeData"]);
                sum += tempWeight;

                if (tempWeight < Convert.ToDouble(Global.dtSensorRealTimeData.Rows[minIndex]["sensorRealTimeData"])){
                    minIndex = i;
                }
                else if (tempWeight > Convert.ToDouble(Global.dtSensorRealTimeData.Rows[maxIndex]["sensorRealTimeData"])){
                    maxIndex = i;
                }
            }

            Global.sensorRealTimeDataPeak = Convert.ToDouble(Global.dtSensorRealTimeData.Rows[maxIndex]["sensorRealTimeData"]);
            Global.sensorRealTimeDataValley= Convert.ToDouble(Global.dtSensorRealTimeData.Rows[minIndex]["sensorRealTimeData"]);
            Global.sensorRealTimeDataAvg = sum / Global.dtSensorRealTimeData.Rows.Count;

            updateConstantPeakValleyAvgLine();
        }

        //刷新峰值、谷值、均值标线位置
        private void updateConstantPeakValleyAvgLine()
        {
            XYDiagram diagram1 = ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram));
            diagram1.AxisY.ConstantLines.Clear();

            ConstantLine clYPeak = new ConstantLine("峰值：" + Global.sensorRealTimeDataPeak.ToString("N3"), Global.sensorRealTimeDataPeak);
            ConstantLine clYAvg = new ConstantLine("平均值：" + Global.sensorRealTimeDataAvg.ToString("N3"), Global.sensorRealTimeDataAvg);
            ConstantLine clYValley = new ConstantLine("谷值：" + Global.sensorRealTimeDataValley.ToString("N3"), Global.sensorRealTimeDataValley);
            clYPeak.Color = Color.FromArgb(56, 152, 83);    
            clYAvg.Color = Color.Red;
            clYValley.Color = Color.FromArgb(204, 109, 0);
            clYPeak.Title.TextColor = Color.FromArgb(62, 112, 56);
            clYAvg.Title.TextColor = Color.Red;
            clYValley.Title.TextColor = Color.FromArgb(204, 109, 0);

            diagram1.AxisY.ConstantLines.Add(clYPeak);
            diagram1.AxisY.ConstantLines.Add(clYValley);
            diagram1.AxisY.ConstantLines.Add(clYAvg);
        }

        private void timer_getDataOnceFromSensor_Tick(object sender, EventArgs e)
        {
            refreshRealTimeCurve();
        }

        //修改坐标轴WholeRange
        private void simpleButton_modifyAxisRange_Click(object sender, EventArgs e)
        {
            int dataLen = Global.dtSensorRealTimeData.Rows.Count;
            double xMinWholeRange = 0.0D;
            double xMaxWholeRange = 0.0D;
            double yMinWholeRange = 0.0D;
            double yMaxWholeRange = 0.0D;

            if (this.textEdit_setXMinVal.Text == "")
            {
                xMinWholeRange = (double)(((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.MinValue);
                this.textEdit_setXMinVal.Text = xMinWholeRange.ToString();
            }
            else
            {
                xMinWholeRange = Convert.ToDouble(this.textEdit_setXMinVal.Text);
            }

            if (this.textEdit_setXMaxVal.Text == "")
            {
                xMaxWholeRange = (double)(((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.MaxValue);
                this.textEdit_setXMaxVal.Text = xMaxWholeRange.ToString();
            }
            else
            {
                xMaxWholeRange = Convert.ToDouble(this.textEdit_setXMaxVal.Text);
            }

            if (this.textEdit_setYMinVal.Text == "")
            {
                yMinWholeRange = (double)(((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.MinValue);
                this.textEdit_setYMinVal.Text = yMinWholeRange.ToString();
            }
            else
            {
                yMinWholeRange = Convert.ToDouble(this.textEdit_setYMinVal.Text);
            }

            if (this.textEdit_setYMaxVal.Text == "")
            {
                yMaxWholeRange = (double)(((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.MaxValue);
                this.textEdit_setYMaxVal.Text = yMaxWholeRange.ToString();
            }
            else
            {
                yMaxWholeRange = Convert.ToDouble(this.textEdit_setYMaxVal.Text);
            }

            if (xMinWholeRange < 0 || xMaxWholeRange <= xMinWholeRange || yMinWholeRange < 0 || yMaxWholeRange <= yMinWholeRange)
            {
                MessageBox.Show("请输入合法的范围");
                return;
            }

            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.SetMinMaxValues(xMinWholeRange, xMaxWholeRange);
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.SetMinMaxValues(yMinWholeRange, yMaxWholeRange);
        }

        //重置坐标轴WholeRange
        private void simpleButton_resetAxisRange_Click(object sender, EventArgs e)
        {
            //横轴重置为Auto，0~xMax
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.Auto = true;
            //Y轴范围设为(valley-k*delta, peak+k*delta)，k为系数，delta为(peak-valley)
            double k = 0.2;
            double delta = Global.sensorRealTimeDataPeak - Global.sensorRealTimeDataValley;
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.SetMinMaxValues(Global.sensorRealTimeDataValley - k * delta, Global.sensorRealTimeDataPeak + k * delta);

            this.textEdit_setXMinVal.Text = "";
            this.textEdit_setXMaxVal.Text = "";
            this.textEdit_setYMinVal.Text = "";
            this.textEdit_setYMaxVal.Text = "";
        }

        private void zoomTrackBarControl_zoomSensorData_ValueChanged(object sender, EventArgs e)
        {
            XYDiagram diagram1 = ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram));
            diagram1.AxisX.VisualRange.MinValue = (double)diagram1.AxisX.WholeRange.MinValue * (zoomTrackBarControl_zoomSensorData.Value / 100);
            diagram1.AxisX.VisualRange.MaxValue = (double)diagram1.AxisX.WholeRange.MaxValue * (zoomTrackBarControl_zoomSensorData.Value / 100);
        }

    }
}
