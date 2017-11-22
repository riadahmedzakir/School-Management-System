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
    public partial class TeacherHighDeleteSelection : MetroFramework.Forms.MetroForm
    {
        private TeacherHigh aTab;
        public TeacherHighDeleteSelection(TeacherHigh a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            TeacherHighDeleteTeacher aSelection = new TeacherHighDeleteTeacher();
            aSelection.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            TeacherHighDeleteStudent bSelection = new TeacherHighDeleteStudent();
            bSelection.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            TeacherHighDeleteParent cSelection = new TeacherHighDeleteParent();
            cSelection.Show();
        }
    }
}
