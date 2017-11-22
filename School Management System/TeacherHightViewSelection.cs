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
    public partial class TeacherHightViewSelection : MetroFramework.Forms.MetroForm
    {
        private TeacherHigh aTab;
        public TeacherHightViewSelection(TeacherHigh a)
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
            this.Hide();
            TeacherHighTeacherView aSelection = new TeacherHighTeacherView(this);
            aSelection.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighStudentView bSelection = new TeacherHighStudentView(this);
            bSelection.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighParentView cSelection = new TeacherHighParentView(this);
            cSelection.Show();
        }
    }
}
