using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_System
{
    public partial class ReportDemoPage : MetroFramework.Forms.MetroForm
    {
        private LoginPage aTab;
        public ReportDemoPage(LoginPage a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }
    }
}
