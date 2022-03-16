
namespace CheckWeighterInterface.SystemManagement
{
    partial class SystemManagement
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
            this.navigationFrame_sysConfig = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage_brandManagement = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_calibrationCorrection = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage_sysConfig = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_sysConfig)).BeginInit();
            this.navigationFrame_sysConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationFrame_sysConfig
            // 
            this.navigationFrame_sysConfig.Controls.Add(this.navigationPage_brandManagement);
            this.navigationFrame_sysConfig.Controls.Add(this.navigationPage_calibrationCorrection);
            this.navigationFrame_sysConfig.Controls.Add(this.navigationPage_sysConfig);
            this.navigationFrame_sysConfig.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame_sysConfig.Name = "navigationFrame_sysConfig";
            this.navigationFrame_sysConfig.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage_brandManagement,
            this.navigationPage_calibrationCorrection,
            this.navigationPage_sysConfig});
            this.navigationFrame_sysConfig.SelectedPage = this.navigationPage_calibrationCorrection;
            this.navigationFrame_sysConfig.Size = new System.Drawing.Size(1024, 617);
            this.navigationFrame_sysConfig.TabIndex = 0;
            this.navigationFrame_sysConfig.Text = "navigationFrame1";
            this.navigationFrame_sysConfig.TransitionAnimationProperties.FrameInterval = 3000;
            // 
            // navigationPage_brandManagement
            // 
            this.navigationPage_brandManagement.Name = "navigationPage_brandManagement";
            this.navigationPage_brandManagement.Size = new System.Drawing.Size(1024, 617);
            // 
            // navigationPage_calibrationCorrection
            // 
            this.navigationPage_calibrationCorrection.Name = "navigationPage_calibrationCorrection";
            this.navigationPage_calibrationCorrection.Size = new System.Drawing.Size(1024, 617);
            // 
            // navigationPage_sysConfig
            // 
            this.navigationPage_sysConfig.Name = "navigationPage_sysConfig";
            this.navigationPage_sysConfig.Size = new System.Drawing.Size(1024, 617);
            // 
            // SystemManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationFrame_sysConfig);
            this.Name = "SystemManagement";
            this.Size = new System.Drawing.Size(1024, 617);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame_sysConfig)).EndInit();
            this.navigationFrame_sysConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame_sysConfig;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_brandManagement;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_calibrationCorrection;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage_sysConfig;
    }
}
