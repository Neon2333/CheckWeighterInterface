﻿
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
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView3 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();
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
            this.labelControl_yWholeRangeZoom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_xWholeRangeZoom = new DevExpress.XtraEditors.LabelControl();
            this.zoomTrackBarControl_yWholeRangeZoom = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.spinEdit_setYMaxVal = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_setYMinVal = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_setXMaxVal = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_setXMinVal = new DevExpress.XtraEditors.SpinEdit();
            this.zoomTrackBarControl_xWholeRangeZoom = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.simpleButton_resetAxisRange = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_yZoom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_xZoom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setXZoom = new DevExpress.XtraEditors.LabelControl();
            this.zoomTrackBarControl_YRange = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.zoomTrackBarControl_XRange = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.simpleButton_modifyAxisRange = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl_setYMax = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setYMin = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setXMax = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_setXMin = new DevExpress.XtraEditors.LabelControl();
            this.separatorControl_left = new DevExpress.XtraEditors.SeparatorControl();
            this.timer_getDataOnceFromSensor = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_weighterSensorRealTimeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_weightList)).BeginInit();
            this.panelControl_weightList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_yWholeRangeZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_yWholeRangeZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setYMaxVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setYMinVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setXMaxVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setXMinVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_xWholeRangeZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_xWholeRangeZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl_left)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl_weighterSensorRealTimeData
            // 
            xyDiagram3.AxisX.GridLines.Visible = true;
            xyDiagram3.AxisX.Interlaced = true;
            xyDiagram3.AxisX.Label.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram3.AxisX.Title.Text = "传感器检测次数";
            xyDiagram3.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram3.AxisX.WholeRange.EndSideMargin = 0.1D;
            xyDiagram3.AxisX.WholeRange.StartSideMargin = 0.1D;
            xyDiagram3.AxisY.Label.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            xyDiagram3.AxisY.MinorCount = 6;
            xyDiagram3.AxisY.Title.Text = "传感器实时数据 KG";
            xyDiagram3.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.VisualRange.Auto = false;
            xyDiagram3.AxisY.VisualRange.AutoSideMargins = false;
            xyDiagram3.AxisY.VisualRange.EndSideMargin = 0D;
            xyDiagram3.AxisY.VisualRange.MaxValueSerializable = "30";
            xyDiagram3.AxisY.VisualRange.MinValueSerializable = "5";
            xyDiagram3.AxisY.VisualRange.StartSideMargin = 0D;
            xyDiagram3.AxisY.WholeRange.Auto = false;
            xyDiagram3.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram3.AxisY.WholeRange.EndSideMargin = 0D;
            xyDiagram3.AxisY.WholeRange.MaxValueSerializable = "30";
            xyDiagram3.AxisY.WholeRange.MinValueSerializable = "5";
            xyDiagram3.AxisY.WholeRange.StartSideMargin = 0D;
            xyDiagram3.EnableAxisXScrolling = true;
            xyDiagram3.EnableAxisXZooming = true;
            xyDiagram3.EnableAxisYScrolling = true;
            xyDiagram3.EnableAxisYZooming = true;
            this.chartControl_weighterSensorRealTimeData.Diagram = xyDiagram3;
            this.chartControl_weighterSensorRealTimeData.Legend.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl_weighterSensorRealTimeData.Legend.Name = "Default Legend";
            this.chartControl_weighterSensorRealTimeData.Location = new System.Drawing.Point(275, 3);
            this.chartControl_weighterSensorRealTimeData.Name = "chartControl_weighterSensorRealTimeData";
            series3.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series3.Name = "实时数据";
            splineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            series3.View = splineSeriesView3;
            this.chartControl_weighterSensorRealTimeData.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chartControl_weighterSensorRealTimeData.Size = new System.Drawing.Size(746, 611);
            this.chartControl_weighterSensorRealTimeData.TabIndex = 4;
            chartTitle3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle3.Text = "检重传感器实时数据";
            this.chartControl_weighterSensorRealTimeData.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle3});
            // 
            // labelControl_peakValue
            // 
            this.labelControl_peakValue.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_peakValue.Appearance.Options.UseFont = true;
            this.labelControl_peakValue.Appearance.Options.UseTextOptions = true;
            this.labelControl_peakValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_peakValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_peakValue.Location = new System.Drawing.Point(38, 25);
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
            this.labelControl_valleyValue.Location = new System.Drawing.Point(38, 69);
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
            this.labelControl_averageValue.Location = new System.Drawing.Point(38, 115);
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
            this.labelControl_peakValueVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl_peakValueVal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_peakValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_peakValueVal.Location = new System.Drawing.Point(119, 25);
            this.labelControl_peakValueVal.Name = "labelControl_peakValueVal";
            this.labelControl_peakValueVal.Size = new System.Drawing.Size(92, 28);
            this.labelControl_peakValueVal.TabIndex = 14;
            // 
            // labelControl_valleyValueVal
            // 
            this.labelControl_valleyValueVal.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_valleyValueVal.Appearance.Options.UseFont = true;
            this.labelControl_valleyValueVal.Appearance.Options.UseTextOptions = true;
            this.labelControl_valleyValueVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl_valleyValueVal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_valleyValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_valleyValueVal.Location = new System.Drawing.Point(119, 69);
            this.labelControl_valleyValueVal.Name = "labelControl_valleyValueVal";
            this.labelControl_valleyValueVal.Size = new System.Drawing.Size(92, 28);
            this.labelControl_valleyValueVal.TabIndex = 15;
            // 
            // labelControl_averageValueVal
            // 
            this.labelControl_averageValueVal.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_averageValueVal.Appearance.Options.UseFont = true;
            this.labelControl_averageValueVal.Appearance.Options.UseTextOptions = true;
            this.labelControl_averageValueVal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl_averageValueVal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_averageValueVal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_averageValueVal.Location = new System.Drawing.Point(119, 115);
            this.labelControl_averageValueVal.Name = "labelControl_averageValueVal";
            this.labelControl_averageValueVal.Size = new System.Drawing.Size(92, 28);
            this.labelControl_averageValueVal.TabIndex = 16;
            // 
            // labelControl_KG1
            // 
            this.labelControl_KG1.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_KG1.Appearance.Options.UseFont = true;
            this.labelControl_KG1.Location = new System.Drawing.Point(217, 25);
            this.labelControl_KG1.Name = "labelControl_KG1";
            this.labelControl_KG1.Size = new System.Drawing.Size(29, 28);
            this.labelControl_KG1.TabIndex = 22;
            this.labelControl_KG1.Text = "KG";
            // 
            // labelControl_KG2
            // 
            this.labelControl_KG2.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_KG2.Appearance.Options.UseFont = true;
            this.labelControl_KG2.Location = new System.Drawing.Point(217, 69);
            this.labelControl_KG2.Name = "labelControl_KG2";
            this.labelControl_KG2.Size = new System.Drawing.Size(29, 28);
            this.labelControl_KG2.TabIndex = 23;
            this.labelControl_KG2.Text = "KG";
            // 
            // labelControl_KG3
            // 
            this.labelControl_KG3.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_KG3.Appearance.Options.UseFont = true;
            this.labelControl_KG3.Location = new System.Drawing.Point(217, 115);
            this.labelControl_KG3.Name = "labelControl_KG3";
            this.labelControl_KG3.Size = new System.Drawing.Size(29, 28);
            this.labelControl_KG3.TabIndex = 24;
            this.labelControl_KG3.Text = "KG";
            // 
            // panelControl_weightList
            // 
            this.panelControl_weightList.Controls.Add(this.labelControl_yWholeRangeZoom);
            this.panelControl_weightList.Controls.Add(this.labelControl_xWholeRangeZoom);
            this.panelControl_weightList.Controls.Add(this.zoomTrackBarControl_yWholeRangeZoom);
            this.panelControl_weightList.Controls.Add(this.spinEdit_setYMaxVal);
            this.panelControl_weightList.Controls.Add(this.spinEdit_setYMinVal);
            this.panelControl_weightList.Controls.Add(this.spinEdit_setXMaxVal);
            this.panelControl_weightList.Controls.Add(this.spinEdit_setXMinVal);
            this.panelControl_weightList.Controls.Add(this.zoomTrackBarControl_xWholeRangeZoom);
            this.panelControl_weightList.Controls.Add(this.simpleButton_resetAxisRange);
            this.panelControl_weightList.Controls.Add(this.labelControl_yZoom);
            this.panelControl_weightList.Controls.Add(this.labelControl1);
            this.panelControl_weightList.Controls.Add(this.labelControl_xZoom);
            this.panelControl_weightList.Controls.Add(this.labelControl_setXZoom);
            this.panelControl_weightList.Controls.Add(this.zoomTrackBarControl_YRange);
            this.panelControl_weightList.Controls.Add(this.zoomTrackBarControl_XRange);
            this.panelControl_weightList.Controls.Add(this.simpleButton_modifyAxisRange);
            this.panelControl_weightList.Controls.Add(this.labelControl_setYMax);
            this.panelControl_weightList.Controls.Add(this.labelControl_setYMin);
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
            this.panelControl_weightList.Size = new System.Drawing.Size(266, 611);
            this.panelControl_weightList.TabIndex = 25;
            // 
            // labelControl_yWholeRangeZoom
            // 
            this.labelControl_yWholeRangeZoom.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_yWholeRangeZoom.Appearance.Options.UseFont = true;
            this.labelControl_yWholeRangeZoom.Appearance.Options.UseTextOptions = true;
            this.labelControl_yWholeRangeZoom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_yWholeRangeZoom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_yWholeRangeZoom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_yWholeRangeZoom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl_yWholeRangeZoom.Location = new System.Drawing.Point(222, 177);
            this.labelControl_yWholeRangeZoom.Name = "labelControl_yWholeRangeZoom";
            this.labelControl_yWholeRangeZoom.Size = new System.Drawing.Size(32, 19);
            this.labelControl_yWholeRangeZoom.TabIndex = 57;
            this.labelControl_yWholeRangeZoom.Text = "Y×1";
            // 
            // labelControl_xWholeRangeZoom
            // 
            this.labelControl_xWholeRangeZoom.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl_xWholeRangeZoom.Appearance.Options.UseFont = true;
            this.labelControl_xWholeRangeZoom.Appearance.Options.UseTextOptions = true;
            this.labelControl_xWholeRangeZoom.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_xWholeRangeZoom.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_xWholeRangeZoom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl_xWholeRangeZoom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl_xWholeRangeZoom.Location = new System.Drawing.Point(169, 177);
            this.labelControl_xWholeRangeZoom.Name = "labelControl_xWholeRangeZoom";
            this.labelControl_xWholeRangeZoom.Size = new System.Drawing.Size(32, 19);
            this.labelControl_xWholeRangeZoom.TabIndex = 56;
            this.labelControl_xWholeRangeZoom.Text = "X×1";
            // 
            // zoomTrackBarControl_yWholeRangeZoom
            // 
            this.zoomTrackBarControl_yWholeRangeZoom.EditValue = 100;
            this.zoomTrackBarControl_yWholeRangeZoom.Location = new System.Drawing.Point(222, 201);
            this.zoomTrackBarControl_yWholeRangeZoom.Name = "zoomTrackBarControl_yWholeRangeZoom";
            this.zoomTrackBarControl_yWholeRangeZoom.Properties.AutoSize = false;
            this.zoomTrackBarControl_yWholeRangeZoom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.zoomTrackBarControl_yWholeRangeZoom.Properties.Maximum = 200;
            this.zoomTrackBarControl_yWholeRangeZoom.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomTrackBarControl_yWholeRangeZoom.Size = new System.Drawing.Size(32, 209);
            this.zoomTrackBarControl_yWholeRangeZoom.TabIndex = 55;
            this.zoomTrackBarControl_yWholeRangeZoom.Value = 100;
            this.zoomTrackBarControl_yWholeRangeZoom.ValueChanged += new System.EventHandler(this.zoomTrackBarControl_yWholeRangeZoom_ValueChanged);
            // 
            // spinEdit_setYMaxVal
            // 
            this.spinEdit_setYMaxVal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_setYMaxVal.Location = new System.Drawing.Point(5, 381);
            this.spinEdit_setYMaxVal.Name = "spinEdit_setYMaxVal";
            this.spinEdit_setYMaxVal.Properties.AutoHeight = false;
            this.spinEdit_setYMaxVal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_setYMaxVal.Size = new System.Drawing.Size(140, 29);
            this.spinEdit_setYMaxVal.TabIndex = 54;
            this.spinEdit_setYMaxVal.ValueChanged += new System.EventHandler(this.spinEdit_setYMaxVal_ValueChanged);
            // 
            // spinEdit_setYMinVal
            // 
            this.spinEdit_setYMinVal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_setYMinVal.Location = new System.Drawing.Point(5, 321);
            this.spinEdit_setYMinVal.Name = "spinEdit_setYMinVal";
            this.spinEdit_setYMinVal.Properties.AutoHeight = false;
            this.spinEdit_setYMinVal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_setYMinVal.Size = new System.Drawing.Size(140, 29);
            this.spinEdit_setYMinVal.TabIndex = 53;
            this.spinEdit_setYMinVal.ValueChanged += new System.EventHandler(this.spinEdit_setYMinVal_ValueChanged);
            // 
            // spinEdit_setXMaxVal
            // 
            this.spinEdit_setXMaxVal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_setXMaxVal.Location = new System.Drawing.Point(5, 261);
            this.spinEdit_setXMaxVal.Name = "spinEdit_setXMaxVal";
            this.spinEdit_setXMaxVal.Properties.AutoHeight = false;
            this.spinEdit_setXMaxVal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_setXMaxVal.Size = new System.Drawing.Size(140, 29);
            this.spinEdit_setXMaxVal.TabIndex = 49;
            this.spinEdit_setXMaxVal.ValueChanged += new System.EventHandler(this.spinEdit_setXMaxVal_ValueChanged);
            // 
            // spinEdit_setXMinVal
            // 
            this.spinEdit_setXMinVal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_setXMinVal.Location = new System.Drawing.Point(5, 201);
            this.spinEdit_setXMinVal.Name = "spinEdit_setXMinVal";
            this.spinEdit_setXMinVal.Properties.AutoHeight = false;
            this.spinEdit_setXMinVal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_setXMinVal.Size = new System.Drawing.Size(140, 29);
            this.spinEdit_setXMinVal.TabIndex = 37;
            this.spinEdit_setXMinVal.ValueChanged += new System.EventHandler(this.spinEdit_setXMinVal_ValueChanged);
            // 
            // zoomTrackBarControl_xWholeRangeZoom
            // 
            this.zoomTrackBarControl_xWholeRangeZoom.EditValue = 100;
            this.zoomTrackBarControl_xWholeRangeZoom.Location = new System.Drawing.Point(169, 201);
            this.zoomTrackBarControl_xWholeRangeZoom.Name = "zoomTrackBarControl_xWholeRangeZoom";
            this.zoomTrackBarControl_xWholeRangeZoom.Properties.AutoSize = false;
            this.zoomTrackBarControl_xWholeRangeZoom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.zoomTrackBarControl_xWholeRangeZoom.Properties.Maximum = 200;
            this.zoomTrackBarControl_xWholeRangeZoom.Properties.Middle = 100;
            this.zoomTrackBarControl_xWholeRangeZoom.Properties.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomTrackBarControl_xWholeRangeZoom.Size = new System.Drawing.Size(32, 209);
            this.zoomTrackBarControl_xWholeRangeZoom.TabIndex = 46;
            this.zoomTrackBarControl_xWholeRangeZoom.Value = 100;
            this.zoomTrackBarControl_xWholeRangeZoom.ValueChanged += new System.EventHandler(this.zoomTrackBarControl_xWholeRange_ValueChanged);
            // 
            // simpleButton_resetAxisRange
            // 
            this.simpleButton_resetAxisRange.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleButton_resetAxisRange.Appearance.Options.UseFont = true;
            this.simpleButton_resetAxisRange.AppearancePressed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButton_resetAxisRange.AppearancePressed.Options.UseFont = true;
            this.simpleButton_resetAxisRange.Location = new System.Drawing.Point(135, 418);
            this.simpleButton_resetAxisRange.Name = "simpleButton_resetAxisRange";
            this.simpleButton_resetAxisRange.Size = new System.Drawing.Size(126, 55);
            this.simpleButton_resetAxisRange.TabIndex = 44;
            this.simpleButton_resetAxisRange.Text = "坐标轴范围自动";
            this.simpleButton_resetAxisRange.Click += new System.EventHandler(this.simpleButton_resetAxisRange_Click);
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
            this.zoomTrackBarControl_XRange.EditValue = null;
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
            this.simpleButton_modifyAxisRange.Location = new System.Drawing.Point(5, 418);
            this.simpleButton_modifyAxisRange.Name = "simpleButton_modifyAxisRange";
            this.simpleButton_modifyAxisRange.Size = new System.Drawing.Size(126, 55);
            this.simpleButton_modifyAxisRange.TabIndex = 39;
            this.simpleButton_modifyAxisRange.Text = "修改坐标轴范围";
            this.simpleButton_modifyAxisRange.Click += new System.EventHandler(this.simpleButton_modifyAxisRange_Click);
            // 
            // labelControl_setYMax
            // 
            this.labelControl_setYMax.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl_setYMax.Appearance.Options.UseFont = true;
            this.labelControl_setYMax.Appearance.Options.UseTextOptions = true;
            this.labelControl_setYMax.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setYMax.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setYMax.Location = new System.Drawing.Point(5, 356);
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
            this.labelControl_setYMin.Location = new System.Drawing.Point(5, 296);
            this.labelControl_setYMin.Name = "labelControl_setYMin";
            this.labelControl_setYMin.Size = new System.Drawing.Size(112, 19);
            this.labelControl_setYMin.TabIndex = 35;
            this.labelControl_setYMin.Text = "设定纵轴最小值：";
            // 
            // labelControl_setXMax
            // 
            this.labelControl_setXMax.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl_setXMax.Appearance.Options.UseFont = true;
            this.labelControl_setXMax.Appearance.Options.UseTextOptions = true;
            this.labelControl_setXMax.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl_setXMax.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl_setXMax.Location = new System.Drawing.Point(5, 236);
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
            this.labelControl_setXMin.Location = new System.Drawing.Point(5, 176);
            this.labelControl_setXMin.Name = "labelControl_setXMin";
            this.labelControl_setXMin.Size = new System.Drawing.Size(112, 19);
            this.labelControl_setXMin.TabIndex = 30;
            this.labelControl_setXMin.Text = "设定横轴最小值：";
            // 
            // separatorControl_left
            // 
            this.separatorControl_left.LineAlignment = DevExpress.XtraEditors.Alignment.Center;
            this.separatorControl_left.Location = new System.Drawing.Point(2, 149);
            this.separatorControl_left.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.separatorControl_left.LookAndFeel.UseDefaultLookAndFeel = false;
            this.separatorControl_left.Name = "separatorControl_left";
            this.separatorControl_left.Size = new System.Drawing.Size(263, 21);
            this.separatorControl_left.TabIndex = 29;
            // 
            // timer_getDataOnceFromSensor
            // 
            this.timer_getDataOnceFromSensor.Enabled = true;
            this.timer_getDataOnceFromSensor.Tick += new System.EventHandler(this.timer_getDataOnceFromSensor_Tick);
            // 
            // RealTimeCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl_weightList);
            this.Controls.Add(this.chartControl_weighterSensorRealTimeData);
            this.Name = "RealTimeCurve";
            this.Size = new System.Drawing.Size(1024, 617);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl_weighterSensorRealTimeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_weightList)).EndInit();
            this.panelControl_weightList.ResumeLayout(false);
            this.panelControl_weightList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_yWholeRangeZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_yWholeRangeZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setYMaxVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setYMinVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setXMaxVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_setXMinVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_xWholeRangeZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_xWholeRangeZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_YRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl_XRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl_left)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.LabelControl labelControl_setXMax;
        private DevExpress.XtraEditors.LabelControl labelControl_setXMin;
        private DevExpress.XtraEditors.LabelControl labelControl_setYMax;
        private DevExpress.XtraEditors.LabelControl labelControl_setYMin;
        private System.Windows.Forms.Timer timer_getDataOnceFromSensor;
        private DevExpress.XtraEditors.SimpleButton simpleButton_modifyAxisRange;
        private DevExpress.XtraEditors.SimpleButton simpleButton_resetAxisRange;
        private DevExpress.XtraEditors.LabelControl labelControl_yZoom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl_xZoom;
        private DevExpress.XtraEditors.LabelControl labelControl_setXZoom;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_YRange;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_XRange;
        private DevExpress.XtraEditors.SpinEdit spinEdit_setXMinVal;
        private DevExpress.XtraEditors.SpinEdit spinEdit_setXMaxVal;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_xWholeRangeZoom;
        private DevExpress.XtraEditors.SpinEdit spinEdit_setYMaxVal;
        private DevExpress.XtraEditors.SpinEdit spinEdit_setYMinVal;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl_yWholeRangeZoom;
        private DevExpress.XtraEditors.LabelControl labelControl_xWholeRangeZoom;
        private DevExpress.XtraEditors.LabelControl labelControl_yWholeRangeZoom;
    }
}
