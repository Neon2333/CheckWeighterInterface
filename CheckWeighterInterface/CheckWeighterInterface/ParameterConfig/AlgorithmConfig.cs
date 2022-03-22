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

namespace CheckWeighterInterface.ParameterConfig
{
    public partial class AlgorithmConfig : DevExpress.XtraEditors.XtraUserControl
    {
        public AlgorithmConfig()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            int[] a = { 0, 2, 4, 5, 9 };
            Global.FilteringFunc ff = new Global.FilteringFunc();
            int b = ff.medianFiltering(5, a);
            

        }


    }
}
