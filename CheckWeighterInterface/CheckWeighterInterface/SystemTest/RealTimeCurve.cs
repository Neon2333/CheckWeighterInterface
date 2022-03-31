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
        //修改：坐标轴范围WholeRange
        private double xMinWholeRange = 0.0D;
        private double xMaxWholeRange = 0.0D;
        private double yMinWholeRange = 0.0D;
        private double yMaxWholeRange = 0.0D;
        //修改：spinEdit显示的坐标轴范围
        private double xMinWholeRangeSpin = 0.0D;
        private double xMaxWholeRangeSpin = 0.0D;
        private double yMinWholeRangeSpin = 0.0D;
        private double yMaxWholeRangeSpin = 0.0D;
        //重置：
        private double yMaxWholeRangeReset = 0.5D;
        //坐标轴范围倍率数组
        private double[] wholeRangeZoomArr = new double[101];
        //坐标轴缩放倍率数组
        private double[] visualRangeZoomArr = new double[101];






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
            initVisualRangeZoomArr();
            initWholeRangeZoomArr();
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
                updatePeakValleyAvgLabel();
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
            diagram1.AxisY.ConstantLines.Clear();   //清除上次绘制曲线

            diagram1.AxisY.ConstantLines.Add(new ConstantLine("Y=0", 0));

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

        private void updatePeakValleyAvgLabel()
        {
            this.labelControl_peakValueVal.Text = Global.sensorRealTimeDataPeak.ToString("N3");
            this.labelControl_valleyValueVal.Text = Global.sensorRealTimeDataValley.ToString("N3");
            this.labelControl_averageValueVal.Text = Global.sensorRealTimeDataAvg.ToString("N3");
        }

        //修改坐标轴WholeRange
        private void simpleButton_modifyAxisRange_Click(object sender, EventArgs e)
        {
            int dataLen = Global.dtSensorRealTimeData.Rows.Count;
            
            //xMin==0,xMax==0
            if (this.spinEdit_setXMinVal.Text == "0" && this.spinEdit_setXMaxVal.Text == "0")
            {
                MessageBox.Show("请输入合法的范围");
                return;
            }

            //yMin==0,yMax==0
            if (this.spinEdit_setYMinVal.Text == "0" && this.spinEdit_setYMaxVal.Text == "0")
            {
                MessageBox.Show("请输入合法的范围");
                return;
            }

            xMinWholeRangeSpin = Convert.ToDouble(this.spinEdit_setXMinVal.Text);
            xMaxWholeRangeSpin = Convert.ToDouble(this.spinEdit_setXMaxVal.Text);
            yMinWholeRangeSpin = Convert.ToDouble(this.spinEdit_setYMinVal.Text);
            yMaxWholeRangeSpin = Convert.ToDouble(this.spinEdit_setYMaxVal.Text);

            if (xMinWholeRangeSpin < 0 || xMaxWholeRangeSpin <= xMinWholeRangeSpin || yMaxWholeRangeSpin <= yMinWholeRangeSpin)
            {
                MessageBox.Show("请输入合法的范围");
                return;
            }
            else
            {
                xMinWholeRange = xMinWholeRangeSpin;
                xMaxWholeRange = xMaxWholeRangeSpin;
                yMinWholeRange = yMinWholeRangeSpin;
                yMaxWholeRange = yMaxWholeRangeSpin;

                this.zoomTrackBarControl_xWholeRangeZoom.Enabled = true;
                this.zoomTrackBarControl_xWholeRangeZoom.Value = 50;
                this.zoomTrackBarControl_yWholeRangeZoom.Enabled = true;
                this.zoomTrackBarControl_yWholeRangeZoom.Value = 50;

                this.zoomTrackBarControl_xVisualRangeZoom.Enabled = true;
                this.zoomTrackBarControl_xVisualRangeZoom.Value = 1;
                this.zoomTrackBarControl_yVisualRangeZoom.Enabled = true;
                this.zoomTrackBarControl_yVisualRangeZoom.Value = 1;
            }

            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.SetMinMaxValues(xMinWholeRange, xMaxWholeRange);
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.SetMinMaxValues(yMinWholeRange, yMaxWholeRange);
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.VisualRange.Auto = true;
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.VisualRange.Auto = true;
        }

        //重置坐标轴WholeRange，横轴自动，纵轴留yMaxWholeRangeReset*(min~max)余量
        private void simpleButton_resetAxisRange_Click(object sender, EventArgs e)
        {
            this.zoomTrackBarControl_xWholeRangeZoom.Value = 50;
            this.zoomTrackBarControl_xWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yWholeRangeZoom.Value = 50;
            this.zoomTrackBarControl_yWholeRangeZoom.Enabled = false;

            this.zoomTrackBarControl_xVisualRangeZoom.Value = 1;
            this.zoomTrackBarControl_xVisualRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yVisualRangeZoom.Value = 1;
            this.zoomTrackBarControl_yVisualRangeZoom.Enabled = false;

            //横轴重置为Auto，0~xMax
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.Auto = true;
            //Y轴范围设为(valley-k*delta, peak+k*delta)，yMaxWholeRangeReset为系数，delta为(peak-valley)
            double delta = Global.sensorRealTimeDataPeak - Global.sensorRealTimeDataValley;
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.SetMinMaxValues(Global.sensorRealTimeDataValley - yMaxWholeRangeReset * delta, Global.sensorRealTimeDataPeak + yMaxWholeRangeReset * delta);

            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.VisualRange.Auto = true;
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.VisualRange.Auto = true;
        }

        private void initWholeRangeZoomArr()
        {
            for (int i = 1; i < 101; i++)
            {
                wholeRangeZoomArr[i] = ((double)(i << 1) / 100.0D);
            }
            wholeRangeZoomArr[0] = wholeRangeZoomArr[1];    //倍率为0时无意义，令其同1
        }

        private void zoomTrackBarControl_xWholeRange_ValueChanged(object sender, EventArgs e)
        {
            int valueTemp = zoomTrackBarControl_xWholeRangeZoom.Value;
            double xWholeRangeZoom = wholeRangeZoomArr[valueTemp];
            xMaxWholeRange = xMinWholeRange + (xMaxWholeRangeSpin - xMinWholeRange) * xWholeRangeZoom;

            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.WholeRange.SetMinMaxValues(xMinWholeRange, xMaxWholeRange);
            this.labelControl_xWholeRangeZoom.Text = "X×" + xWholeRangeZoom.ToString();
        }

        private void zoomTrackBarControl_yWholeRangeZoom_ValueChanged(object sender, EventArgs e)
        {
            int valueTemp = zoomTrackBarControl_yWholeRangeZoom.Value;
            double yWholeRangeZoom = wholeRangeZoomArr[valueTemp];
            yMaxWholeRange = yMinWholeRange + (yMaxWholeRangeSpin - yMinWholeRange) * yWholeRangeZoom;

            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.WholeRange.SetMinMaxValues(yMinWholeRange, yMaxWholeRange);
            this.labelControl_yWholeRangeZoom.Text = "Y×" + yWholeRangeZoom.ToString();
        }

        private void spinEdit_setXMinVal_ValueChanged(object sender, EventArgs e)
        {
            this.zoomTrackBarControl_xWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_xVisualRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yVisualRangeZoom.Enabled = false;
        }

        private void spinEdit_setXMaxVal_ValueChanged(object sender, EventArgs e)
        {
            this.zoomTrackBarControl_xWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_xVisualRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yVisualRangeZoom.Enabled = false;
        }

        private void spinEdit_setYMinVal_ValueChanged(object sender, EventArgs e)
        {
            this.zoomTrackBarControl_xWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_xVisualRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yVisualRangeZoom.Enabled = false;
        }

        private void spinEdit_setYMaxVal_ValueChanged(object sender, EventArgs e)
        {
            this.zoomTrackBarControl_xWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yWholeRangeZoom.Enabled = false;
            this.zoomTrackBarControl_xVisualRangeZoom.Enabled = false;
            this.zoomTrackBarControl_yVisualRangeZoom.Enabled = false;
        }

        //初始化坐标轴缩放时的倍率数组，避免实时计算提高速度
        private void initVisualRangeZoomArr()
        {
            for(int i = 1; i < 101; i++)
            {
                visualRangeZoomArr[i] = 1.0D / (double)i;
            }
            visualRangeZoomArr[0] = visualRangeZoomArr[1];    //倍率为0时无意义，令其同1
        }

        private void zoomTrackBarControl_xVisualRange_ValueChanged(object sender, EventArgs e)
        {
            XYDiagram diagram1 = ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram));

            double xMinVisualRange = 0.0D;  //Visual范围最小值
            double xMaxVisualRange = 0.0D;  //Visual范围最大值
            double xMinWholeRangeTemp = (double)diagram1.AxisX.WholeRange.MinValue;         //Whole范围最小值
            double xMaxWholeRangeTemp = (double)diagram1.AxisX.WholeRange.MaxValue;         //Whole范围最大值
            double xWholeRangeMiddle = (xMinWholeRangeTemp + xMaxWholeRangeTemp) / 2.0D;    //Whole范围中值
            double xWholeRangeDelta = xMaxWholeRangeTemp - xMinWholeRangeTemp;              //Whole范围差值

            if (zoomTrackBarControl_xVisualRangeZoom.Value == 1)
            {
                //放大倍数为1时，令VisualRange = WholeRange
                xMinVisualRange = xMinWholeRangeTemp;
                xMaxVisualRange = xMaxWholeRangeTemp;
            }

            int valueTemp = zoomTrackBarControl_xVisualRangeZoom.Value;
            double xVisualRangeZoom = visualRangeZoomArr[valueTemp];
            xMinVisualRange = xWholeRangeMiddle - (xWholeRangeDelta * xVisualRangeZoom) /2.0D;    //minVisualRange'=WholeRange中位值-(delta/2)*缩放比例
            xMaxVisualRange = xWholeRangeMiddle + (xWholeRangeDelta * xVisualRangeZoom) /2.0D;    //maxVisualRange'=WholeRange中位值+(delta/2)*缩放比例
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisX.VisualRange.SetMinMaxValues(xMinVisualRange, xMaxVisualRange);

            this.labelControl_xVisualRangeZoom.Text = "X×" + valueTemp.ToString();
        }

        private void zoomTrackBarControl_yVisualRange_ValueChanged(object sender, EventArgs e)
        {
            XYDiagram diagram1 = ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram));

            double yMinVisualRange = 0.0D;
            double yMaxVisualRange = 0.0D;
            double yMinWholeRangeTemp = (double)diagram1.AxisY.WholeRange.MinValue;
            double yMaxWholeRangeTemp = (double)diagram1.AxisY.WholeRange.MaxValue;
            double yWholeRangeMiddle = (yMinWholeRangeTemp + yMaxWholeRangeTemp) / 2.0D;    //Whole范围中值
            double yWholeRangeDelta = yMaxWholeRangeTemp - yMinWholeRangeTemp;              //Whole范围差值

            if (zoomTrackBarControl_yVisualRangeZoom.Value == 1)
            {
                //放大倍数为1时，VisualRange==WholeRange
                yMinVisualRange = yMinWholeRangeTemp;
                yMaxVisualRange = yMaxWholeRangeTemp;
            }

            int valueTemp = zoomTrackBarControl_yVisualRangeZoom.Value;
            double yVisualRangeZoom = visualRangeZoomArr[valueTemp];
            yMinVisualRange = yWholeRangeMiddle - (yWholeRangeDelta * yVisualRangeZoom) / 2.0D;    
            yMaxVisualRange = yWholeRangeMiddle + (yWholeRangeDelta * yVisualRangeZoom) / 2.0D;    
            ((XYDiagram)(chartControl_weighterSensorRealTimeData.Diagram)).AxisY.VisualRange.SetMinMaxValues(yMinVisualRange, yMaxVisualRange);

            this.labelControl_yVisualRangeZoom.Text = "Y×" + valueTemp.ToString();
        }

        private void timer_getDataOnceFromSensor_Tick(object sender, EventArgs e)
        {
            refreshRealTimeCurve();
        }

    }
}
