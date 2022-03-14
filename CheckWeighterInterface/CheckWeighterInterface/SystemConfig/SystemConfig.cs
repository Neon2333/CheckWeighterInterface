using DevExpress.XtraBars.Navigation;
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

namespace CheckWeighterInterface.SystemConfig
{
    public partial class SystemConfig : DevExpress.XtraEditors.XtraUserControl
    {
        private NavigationPage[] systemConfigPages = new NavigationPage[2];
        private BrandConfig brandConfig1;
        private AuthorityManagement authorityManagement1;

        public SystemConfig()
        {
            InitializeComponent();
            initSystemConfig();
        }

        private void initSystemConfig()
        {
            loadPages();
            initSystemConfigPages();
        }

        private void loadPages()
        {
            //brandManagement
            this.brandConfig1 = new BrandConfig();
            this.navigationPage_brandManagement.Controls.Add(this.brandConfig1);
            this.brandConfig1.Location = new System.Drawing.Point(0, 0);
            this.brandConfig1.Name = "brandManagement1";
            this.brandConfig1.Size = new System.Drawing.Size(1024, 617);
            this.brandConfig1.TabIndex = 0;
            //authorityManagement
            this.authorityManagement1 = new AuthorityManagement();
            this.navigationPage_authorityManagement.Controls.Add(this.authorityManagement1);
            this.authorityManagement1.Location = new System.Drawing.Point(0, 0);
            this.authorityManagement1.Name = "authorityManagement1";
            this.authorityManagement1.Size = new System.Drawing.Size(1024, 617);
            this.authorityManagement1.TabIndex = 1;
        }

        private void initSystemConfigPages()
        {
            systemConfigPages[0] = navigationPage_brandManagement;
            systemConfigPages[1] = navigationPage_authorityManagement;
        }
        public Boolean frameVisible
        {
            get
            {
                return this.navigationFrame_sysConfig.Visible;
            }
            set
            {
                this.navigationFrame_sysConfig.Visible = value;
            }
        }

        public int selectedFramePage
        {
            get
            {
                //return (NavigationPage)this.navigationFrame_statusMonitor.SelectedPage; //SelectedPage是InavigationPage，时NavigationPage的父类
                for (int i = 0; i < systemConfigPages.Length; i++)
                {
                    if (this.navigationFrame_sysConfig.SelectedPage == systemConfigPages[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            set
            {
                this.navigationFrame_sysConfig.SelectedPage = systemConfigPages[value];
            }
        }

        public void setSelectedFramePage(int pageIndex)
        {
            this.navigationFrame_sysConfig.SelectedPage = systemConfigPages[pageIndex];
        }
    }
}
