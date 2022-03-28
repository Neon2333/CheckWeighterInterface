
namespace CheckWeighterInterface.SystemTest
{
    partial class RealTimeCurve
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chartControl_weighterSensorRealTimeData = new DevExpress.XtraCharts.ChartControl();
            this.labelControl_peakValue = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_valleyValue = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_averageValue = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_peakValueVal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_valleyValueVal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_averageValueVal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_KG1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_KG2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_KG3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl_weightList = new DevExpress.XtraEditors.PanelControl();
            this.zoomTrackBarControl_YRange = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.zoomTrackBarControl_XRange = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.simpleButton_modifyAxisRange = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_setYMaxVal = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_setYMinVal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_setYMax = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setYMin = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_setXMaxVal = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_setXMinVal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_setXMax = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setXMin = new DevExpress.XtraEditors.LabelControl();
            this.separatorControl_left = new DevExpress.XtraEditors.SeparatorControl();
            this.timer_getDataOnceFromSensor = new System.Windows.Forms.Timer(this.components);
            this.zoomTrackBarControl_zoomSensorData = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.labelControl_xyZoom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setXZoom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_xZoom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_yZoom = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_resetAxisRange = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_weighterSensorRealTimeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_weightList)).BeginInit();
            this.panelControl_weightList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setYMaxVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setYMinVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setXMaxVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setXMinVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_zoomSensorData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_zoomSensorData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl_weighterSensorRealTimeData
            // 
            xyDiagram2.AxisX.GridLines.Visible = true;
            xyDiagram2.AxisX.Interlaced = true;
            xyDiagram2.AxisX.Label.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisX.Title.Text = "传感器检测次数";
            xyDiagram2.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram2.AxisX.WholeRange.EndSideMargin = 0.1D;
            xyDiagram2.AxisX.WholeRange.StartSideMargin = 0.1D;
            xyDiagram2.AxisY.Label.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            xyDiagram2.AxisY.MinorCount = 6;
            xyDiagram2.AxisY.Title.Text = "传感器实时数据 KG";
            xyDiagram2.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisualRange.Auto = false;
            xyDiagram2.AxisY.VisualRange.AutoSideMargins = false;
            xyDiagram2.AxisY.VisualRange.EndSideMargin = 0D;
            xyDiagram2.AxisY.VisualRange.MaxValueSerializable = "30";
            xyDiagram2.AxisY.VisualRange.MinValueSerializable = "5";
            xyDiagram2.AxisY.VisualRange.StartSideMargin = 0D;
            xyDiagram2.AxisY.WholeRange.Auto = false;
            xyDiagram2.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram2.AxisY.WholeRange.EndSideMargin = 0D;
            xyDiagram2.AxisY.WholeRange.MaxValueSerializable = "30";
            xyDiagram2.AxisY.WholeRange.MinValueSerializable = "5";
            xyDiagram2.AxisY.WholeRange.StartSideMargin = 0D;
            xyDiagram2.EnableAxisXScrolling = true;
            xyDiagram2.EnableAxisXZooming = true;
            xyDiagram2.EnableAxisYScrolling = true;
            xyDiagram2.EnableAxisYZooming = true;
            this.chartControl_weighterSensorRealTimeData.Diagram = xyDiagram2;
            this.chartControl_weighterSensorRealTimeData.Legend.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl_weighterSensorRealTimeData.Legend.Name = "Default Legend";
            this.chartControl_weighterSensorRealTimeData.Location = new System.Drawing.Point(275, 3);
            this.chartControl_weighterSensorRealTimeData.Name = "chartControl_weighterSensorRealTimeData";
            series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series2.Name = "实时数据";
            splineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            series2.View = splineSeriesView2;
            this.chartControl_weighterSensorRealTimeData.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl_weighterSensorRealTimeData.Size = new System.Drawing.Size(746, 604);
            this.chartControl_weighterSensorRealTimeData.TabIndex = 4;
            chartTitle2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle2.Text = "检重传感器实时数据";
            this.chartControl_weighterSensorRealTimeData.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // labelControl_peakValue
            // 
            this.labelControl_peakValue.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_peakValue.Appearance.Options.UseFont = true;
            this.labelControl_peakValue.Appearance.Options.UseTextOptions = true;
            this.labelControl_peakValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_peakValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_peakValue.Location = new System.Drawing.Point(38, 21);
            this.labelControl_peakValue.Name = "labelControl_peakValue";
            this.labelControl_peakValue.Size = new System.Drawing.Size(63, 28);
            this.labelControl_peakValue.TabIndex = 8;
            this.labelControl_peakValue.Text = "峰值：";
            // 
            // labelControl_valleyValue
            // 
            this.labelControl_valleyValue.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_valleyValue.Appearance.Options.UseFont = true;
            this.labelControl_valleyValue.Appearance.Options.UseTextOptions = true;
            this.labelControl_valleyValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_valleyValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_valleyValue.Location = new System.Drawing.Point(38, 77);
            this.labelControl_valleyValue.Name = "labelControl_valleyValue";
            this.labelControl_valleyValue.Size = new System.Drawing.Size(63, 28);
            this.labelControl_valleyValue.TabIndex = 9;
            this.labelControl_valleyValue.Text = "谷值：";
            // 
            // labelControl_averageValue
            // 
            this.labelControl_averageValue.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_averageValue.Appearance.Options.UseFont = true;
            this.labelControl_averageValue.Appearance.Options.UseTextOptions = true;
            this.labelControl_averageValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_averageValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_averageValue.Location = new System.Drawing.Point(38, 137);
            this.labelControl_averageValue.Name = "labelControl_averageValue";
            this.labelControl_averageValue.Size = new System.Drawing.Size(84, 28);
            this.labelControl_averageValue.TabIndex = 10;
            this.labelControl_averageValue.Text = "平均值：";
            // 
            // labelControl_peakValueVal
            // 
            this.labelControl_peakValueVal.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_peakValueVal.Appearance.Options.UseFont = true;
            this.labelControl_peakValueVal.Appearance.Options.UseTextOptions = true;
            this.labelControl_peakValueVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_peakValueVal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_peakValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_peakValueVal.Location = new System.Drawing.Point(119, 21);
            this.labelControl_peakValueVal.Name = "labelControl_peakValueVal";
            this.labelControl_peakValueVal.Size = new System.Drawing.Size(65, 28);
            this.labelControl_peakValueVal.TabIndex = 14;
            // 
            // labelControl_valleyValueVal
            // 
            this.labelControl_valleyValueVal.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_valleyValueVal.Appearance.Options.UseFont = true;
            this.labelControl_valleyValueVal.Appearance.Options.UseTextOptions = true;
            this.labelControl_valleyValueVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_valleyValueVal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_valleyValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_valleyValueVal.Location = new System.Drawing.Point(119, 77);
            this.labelControl_valleyValueVal.Name = "labelControl_valleyValueVal";
            this.labelControl_valleyValueVal.Size = new System.Drawing.Size(65, 28);
            this.labelControl_valleyValueVal.TabIndex = 15;
            // 
            // labelControl_averageValueVal
            // 
            this.labelControl_averageValueVal.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_averageValueVal.Appearance.Options.UseFont = true;
            this.labelControl_averageValueVal.Appearance.Options.UseTextOptions = true;
            this.labelControl_averageValueVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_averageValueVal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_averageValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_averageValueVal.Location = new System.Drawing.Point(119, 137);
            this.labelControl_averageValueVal.Name = "labelControl_averageValueVal";
            this.labelControl_averageValueVal.Size = new System.Drawing.Size(65, 28);
            this.labelControl_averageValueVal.TabIndex = 16;
            // 
            // labelControl_KG1
            // 
            this.labelControl_KG1.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_KG1.Appearance.Options.UseFont = true;
            this.labelControl_KG1.Location = new System.Drawing.Point(217, 21);
            this.labelControl_KG1.Name = "labelControl_KG1";
            this.labelControl_KG1.Size = new System.Drawing.Size(29, 28);
            this.labelControl_KG1.TabIndex = 22;
            this.labelControl_KG1.Text = "KG";
            // 
            // labelControl_KG2
            // 
            this.labelControl_KG2.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_KG2.Appearance.Options.UseFont = true;
            this.labelControl_KG2.Location = new System.Drawing.Point(217, 77);
            this.labelControl_KG2.Name = "labelControl_KG2";
            this.labelControl_KG2.Size = new System.Drawing.Size(29, 28);
            this.labelControl_KG2.TabIndex = 23;
            this.labelControl_KG2.Text = "KG";
            // 
            // labelControl_KG3
            // 
            this.labelControl_KG3.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_KG3.Appearance.Options.UseFont = true;
            this.labelControl_KG3.Location = new System.Drawing.Point(217, 137);
            this.labelControl_KG3.Name = "labelControl_KG3";
            this.labelControl_KG3.Size = new System.Drawing.Size(29, 28);
            this.labelControl_KG3.TabIndex = 24;
            this.labelControl_KG3.Text = "KG";
            // 
            // panelControl_weightList
            // 
            this.panelControl_weightList.Controls.Add(this.simpleButton_resetAxisRange);
            this.panelControl_weightList.Controls.Add(this.labelControl_yZoom);
            this.panelControl_weightList.Controls.Add(this.labelControl1);
            this.panelControl_weightList.Controls.Add(this.labelControl_xZoom);
            this.panelControl_weightList.Controls.Add(this.labelControl_setXZoom);
            this.panelControl_weightList.Controls.Add(this.zoomTrackBarControl_YRange);
            this.panelControl_weightList.Controls.Add(this.zoomTrackBarControl_XRange);
            this.panelControl_weightList.Controls.Add(this.simpleButton_modifyAxisRange);
            this.panelControl_weightList.Controls.Add(this.textEdit_setYMaxVal);
            this.panelControl_weightList.Controls.Add(this.textEdit_setYMinVal);
            this.panelControl_weightList.Controls.Add(this.labelControl_setYMax);
            this.panelControl_weightList.Controls.Add(this.labelControl_setYMin);
            this.panelControl_weightList.Controls.Add(this.textEdit_setXMaxVal);
            this.panelControl_weightList.Controls.Add(this.textEdit_setXMinVal);
            this.panelControl_weightList.Controls.Add(this.labelControl_setXMax);
            this.panelControl_weightList.Controls.Add(this.labelControl_setXMin);
            this.panelControl_weightList.Controls.Add(this.separatorControl_left);
            this.panelControl_weightList.Controls.Add(this.labelControl_KG3);
            this.panelControl_weightList.Controls.Add(this.labelControl_KG2);
            this.panelControl_weightList.Controls.Add(this.labelControl_peakValue);
            this.panelControl_weightList.Controls.Add(this.labelControl_KG1);
            this.panelControl_weightList.Controls.Add(this.labelControl_valleyValue);
            this.panelControl_weightList.Controls.Add(this.labelControl_averageValueVal);
            this.panelControl_weightList.Controls.Add(this.labelControl_averageValue);
            this.panelControl_weightList.Controls.Add(this.labelControl_valleyValueVal);
            this.panelControl_weightList.Controls.Add(this.labelControl_peakValueVal);
            this.panelControl_weightList.Location = new System.Drawing.Point(3, 3);
            this.panelControl_weightList.Name = "panelControl_weightList";
            this.panelControl_weightList.Size = new System.Drawing.Size(266, 604);
            this.panelControl_weightList.TabIndex = 25;
            // 
            // zoomTrackBarControl_YRange
            // 
            this.zoomTrackBarControl_YRange.EditValue = null;
            this.zoomTrackBarControl_YRange.Location = new System.Drawing.Point(5, 569);
            this.zoomTrackBarControl_YRange.Name = "zoomTrackBarControl_YRange";
            this.zoomTrackBarControl_YRange.Properties.AutoSize = false;
            this.zoomTrackBarControl_YRange.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.zoomTrackBarControl_YRange.Size = new System.Drawing.Size(196, 29);
            this.zoomTrackBarControl_YRange.TabIndex = 32;
            // 
            // zoomTrackBarControl_XRange
            // 
            this.zoomTrackBarControl_XRange.Location = new System.Drawing.Point(5, 504);
            this.zoomTrackBarControl_XRange.Name = "zoomTrackBarControl_XRange";
            this.zoomTrackBarControl_XRange.Properties.AutoSize = false;
            this.zoomTrackBarControl_XRange.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.zoomTrackBarControl_XRange.Properties.Maximum = 100;
            this.zoomTrackBarControl_XRange.Size = new System.Drawing.Size(196, 29);
            this.zoomTrackBarControl_XRange.TabIndex = 33;
            // 
            // simpleButton_modifyAxisRange
            // 
            this.simpleButton_modifyAxisRange.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_modifyAxisRange.Appearance.Options.UseFont = true;
            this.simpleButton_modifyAxisRange.AppearancePressed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton_modifyAxisRange.AppearancePressed.Options.UseFont = true;
            this.simpleButton_modifyAxisRange.Location = new System.Drawing.Point(5, 388);
            this.simpleButton_modifyAxisRange.Name = "simpleButton_modifyAxisRange";
            this.simpleButton_modifyAxisRange.Size = new System.Drawing.Size(126, 55);
            this.simpleButton_modifyAxisRange.TabIndex = 39;
            this.simpleButton_modifyAxisRange.Text = "修改坐标轴范围";
            this.simpleButton_modifyAxisRange.Click += new System.EventHandler(this.simpleButton_modifyAxisRange_Click);
            // 
            // textEdit_setYMaxVal
            // 
            this.textEdit_setYMaxVal.Location = new System.Drawing.Point(118, 344);
            this.textEdit_setYMaxVal.Name = "textEdit_setYMaxVal";
            this.textEdit_setYMaxVal.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_setYMaxVal.Properties.Appearance.Options.UseFont = true;
            this.textEdit_setYMaxVal.Size = new System.Drawing.Size(143, 28);
            this.textEdit_setYMaxVal.TabIndex = 38;
            // 
            // textEdit_setYMinVal
            // 
            this.textEdit_setYMinVal.Location = new System.Drawing.Point(118, 299);
            this.textEdit_setYMinVal.Name = "textEdit_setYMinVal";
            this.textEdit_setYMinVal.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_setYMinVal.Properties.Appearance.Options.UseFont = true;
            this.textEdit_setYMinVal.Size = new System.Drawing.Size(143, 28);
            this.textEdit_setYMinVal.TabIndex = 37;
            // 
            // labelControl_setYMax
            // 
            this.labelControl_setYMax.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl_setYMax.Appearance.Options.UseFont = true;
            this.labelControl_setYMax.Appearance.Options.UseTextOptions = true;
            this.labelControl_setYMax.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setYMax.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setYMax.Location = new System.Drawing.Point(5, 353);
            this.labelControl_setYMax.Name = "labelControl_setYMax";
            this.labelControl_setYMax.Size = new System.Drawing.Size(112, 19);
            this.labelControl_setYMax.TabIndex = 36;
            this.labelControl_setYMax.Text = "设定纵轴最大值：";
            // 
            // labelControl_setYMin
            // 
            this.labelControl_setYMin.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl_setYMin.Appearance.Options.UseFont = true;
            this.labelControl_setYMin.Appearance.Options.UseTextOptions = true;
            this.labelControl_setYMin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setYMin.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setYMin.Location = new System.Drawing.Point(5, 304);
            this.labelControl_setYMin.Name = "labelControl_setYMin";
            this.labelControl_setYMin.Size = new System.Drawing.Size(112, 19);
            this.labelControl_setYMin.TabIndex = 35;
            this.labelControl_setYMin.Text = "设定纵轴最小值：";
            // 
            // textEdit_setXMaxVal
            // 
            this.textEdit_setXMaxVal.Location = new System.Drawing.Point(118, 253);
            this.textEdit_setXMaxVal.Name = "textEdit_setXMaxVal";
            this.textEdit_setXMaxVal.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit_setXMaxVal.Properties.Appearance.Options.UseFont = true;
            this.textEdit_setXMaxVal.Size = new System.Drawing.Size(143, 28);
            this.textEdit_setXMaxVal.TabIndex = 34;
            // 
            // textEdit_setXMinVal
            // 
            this.textEdit_setXMinVal.Location = new System.Drawing.Point(118, 206);
            this.textEdit_setXMinVal.Name = "textEdit_setXMinVal";
            this.textEdit_setXMinVal.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit_setXMinVal.Properties.Appearance.Options.UseFont = true;
            this.textEdit_setXMinVal.Size = new System.Drawing.Size(143, 28);
            this.textEdit_setXMinVal.TabIndex = 33;
            // 
            // labelControl_setXMax
            // 
            this.labelControl_setXMax.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl_setXMax.Appearance.Options.UseFont = true;
            this.labelControl_setXMax.Appearance.Options.UseTextOptions = true;
            this.labelControl_setXMax.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setXMax.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setXMax.Location = new System.Drawing.Point(5, 256);
            this.labelControl_setXMax.Name = "labelControl_setXMax";
            this.labelControl_setXMax.Size = new System.Drawing.Size(112, 19);
            this.labelControl_setXMax.TabIndex = 31;
            this.labelControl_setXMax.Text = "设定横轴最大值：";
            // 
            // labelControl_setXMin
            // 
            this.labelControl_setXMin.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_setXMin.Appearance.Options.UseFont = true;
            this.labelControl_setXMin.Appearance.Options.UseTextOptions = true;
            this.labelControl_setXMin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setXMin.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setXMin.Location = new System.Drawing.Point(5, 209);
            this.labelControl_setXMin.Name = "labelControl_setXMin";
            this.labelControl_setXMin.Size = new System.Drawing.Size(112, 19);
            this.labelControl_setXMin.TabIndex = 30;
            this.labelControl_setXMin.Text = "设定横轴最小值：";
            // 
            // separatorControl_left
            // 
            this.separatorControl_left.LineAlignment = DevExpress.XtraEditors.Alignment.Center;
            this.separatorControl_left.Location = new System.Drawing.Point(2, 182);
            this.separatorControl_left.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.separatorControl_left.LookAndFeel.UseDefaultLookAndFeel = false;
            this.separatorControl_left.Name = "separatorControl_left";
            this.separatorControl_left.Size = new System.Drawing.Size(263, 21);
            this.separatorControl_left.TabIndex = 29;
            // 
            // timer_getDataOnceFromSensor
            // 
            this.timer_getDataOnceFromSensor.Enabled = true;
            this.timer_getDataOnceFromSensor.Interval = 10;
            this.timer_getDataOnceFromSensor.Tick += new System.EventHandler(this.timer_getDataOnceFromSensor_Tick);
            // 
            // zoomTrackBarControl_zoomSensorData
            // 
            this.zoomTrackBarControl_zoomSensorData.Location = new System.Drawing.Point(918, 175);
            this.zoomTrackBarControl_zoomSensorData.Name = "zoomTrackBarControl_zoomSensorData";
            this.zoomTrackBarControl_zoomSensorData.Properties.AutoSize = false;
            this.zoomTrackBarControl_zoomSensorData.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.zoomTrackBarControl_zoomSensorData.Properties.Maximum = 100;
            this.zoomTrackBarControl_zoomSensorData.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomTrackBarControl_zoomSensorData.Size = new System.Drawing.Size(41, 376);
            this.zoomTrackBarControl_zoomSensorData.TabIndex = 34;
            this.zoomTrackBarControl_zoomSensorData.ValueChanged += new System.EventHandler(this.zoomTrackBarControl_zoomSensorData_ValueChanged);
            // 
            // labelControl_xyZoom
            // 
            this.labelControl_xyZoom.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_xyZoom.Appearance.Options.UseFont = true;
            this.labelControl_xyZoom.Appearance.Options.UseTextOptions = true;
            this.labelControl_xyZoom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_xyZoom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_xyZoom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl_xyZoom.Location = new System.Drawing.Point(965, 175);
            this.labelControl_xyZoom.Name = "labelControl_xyZoom";
            this.labelControl_xyZoom.Size = new System.Drawing.Size(53, 29);
            this.labelControl_xyZoom.TabIndex = 35;
            this.labelControl_xyZoom.Text = "×100";
            // 
            // labelControl_setXZoom
            // 
            this.labelControl_setXZoom.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_setXZoom.Appearance.Options.UseFont = true;
            this.labelControl_setXZoom.Appearance.Options.UseTextOptions = true;
            this.labelControl_setXZoom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setXZoom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setXZoom.Location = new System.Drawing.Point(5, 479);
            this.labelControl_setXZoom.Name = "labelControl_setXZoom";
            this.labelControl_setXZoom.Size = new System.Drawing.Size(126, 19);
            this.labelControl_setXZoom.TabIndex = 40;
            this.labelControl_setXZoom.Text = "设定横轴缩放比例：";
            // 
            // labelControl_xZoom
            // 
            this.labelControl_xZoom.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_xZoom.Appearance.Options.UseFont = true;
            this.labelControl_xZoom.Appearance.Options.UseTextOptions = true;
            this.labelControl_xZoom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_xZoom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_xZoom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl_xZoom.Location = new System.Drawing.Point(208, 504);
            this.labelControl_xZoom.Name = "labelControl_xZoom";
            this.labelControl_xZoom.Size = new System.Drawing.Size(53, 29);
            this.labelControl_xZoom.TabIndex = 41;
            this.labelControl_xZoom.Text = "×100";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(5, 539);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 19);
            this.labelControl1.TabIndex = 42;
            this.labelControl1.Text = "设定纵轴缩放比例：";
            // 
            // labelControl_yZoom
            // 
            this.labelControl_yZoom.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_yZoom.Appearance.Options.UseFont = true;
            this.labelControl_yZoom.Appearance.Options.UseTextOptions = true;
            this.labelControl_yZoom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_yZoom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_yZoom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl_yZoom.Location = new System.Drawing.Point(208, 569);
            this.labelControl_yZoom.Name = "labelControl_yZoom";
            this.labelControl_yZoom.Size = new System.Drawing.Size(53, 29);
            this.labelControl_yZoom.TabIndex = 43;
            this.labelControl_yZoom.Text = "×100";
            // 
            // simpleButton_resetAxisRange
            // 
            this.simpleButton_resetAxisRange.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_resetAxisRange.Appearance.Options.UseFont = true;
            this.simpleButton_resetAxisRange.AppearancePressed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton_resetAxisRange.AppearancePressed.Options.UseFont = true;
            this.simpleButton_resetAxisRange.Location = new System.Drawing.Point(135, 388);
            this.simpleButton_resetAxisRange.Name = "simpleButton_resetAxisRange";
            this.simpleButton_resetAxisRange.Size = new System.Drawing.Size(126, 55);
            this.simpleButton_resetAxisRange.TabIndex = 44;
            this.simpleButton_resetAxisRange.Text = "坐标轴范围自动";
            this.simpleButton_resetAxisRange.Click += new System.EventHandler(this.simpleButton_resetAxisRange_Click);
            // 
            // RealTimeCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl_xyZoom);
            this.Controls.Add(this.zoomTrackBarControl_zoomSensorData);
            this.Controls.Add(this.panelControl_weightList);
            this.Controls.Add(this.chartControl_weighterSensorRealTimeData);
            this.Name = "RealTimeCurve";
            this.Size = new System.Drawing.Size(1024, 617);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_weighterSensorRealTimeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_weightList)).EndInit();
            this.panelControl_weightList.ResumeLayout(false);
            this.panelControl_weightList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setYMaxVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setYMinVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setXMaxVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_setXMinVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_zoomSensorData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_zoomSensorData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl_weighterSensorRealTimeData;
        private DevExpress.XtraEditors.LabelControl labelControl_peakValue;
        private DevExpress.XtraEditors.LabelControl labelControl_valleyValue;
        private DevExpress.XtraEditors.LabelControl labelControl_averageValue;
        private DevExpress.XtraEditors.LabelControl labelControl_peakValueVal;
        private DevExpress.XtraEditors.LabelControl labelControl_valleyValueVal;
        private DevExpress.XtraEditors.LabelControl labelControl_averageValueVal;
        private DevExpress.XtraEditors.LabelControl labelControl_KG1;
        private DevExpress.XtraEditors.LabelControl labelControl_KG2;
        private DevExpress.XtraEditors.LabelControl labelControl_KG3;
        private DevExpress.XtraEditors.PanelControl panelControl_weightList;
        private DevExpress.XtraEditors.SeparatorControl separatorControl_left;
        private DevExpress.XtraEditors.TextEdit textEdit_setXMaxVal;
        private DevExpress.XtraEditors.TextEdit textEdit_setXMinVal;
        private DevExpress.XtraEditors.LabelControl labelControl_setXMax;
        private DevExpress.XtraEditors.LabelControl labelControl_setXMin;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_YRange;
        private DevExpress.XtraEditors.LabelControl labelControl_setYMax;
        private DevExpress.XtraEditors.LabelControl labelControl_setYMin;
        private DevExpress.XtraEditors.TextEdit textEdit_setYMaxVal;
        private DevExpress.XtraEditors.TextEdit textEdit_setYMinVal;
        private System.Windows.Forms.Timer timer_getDataOnceFromSensor;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_XRange;
        private DevExpress.XtraEditors.SimpleButton simpleButton_modifyAxisRange;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_zoomSensorData;
        private DevExpress.XtraEditors.LabelControl labelControl_xyZoom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl_xZoom;
        private DevExpress.XtraEditors.LabelControl labelControl_setXZoom;
        private DevExpress.XtraEditors.LabelControl labelControl_yZoom;
        private DevExpress.XtraEditors.SimpleButton simpleButton_resetAxisRange;
    }
}
