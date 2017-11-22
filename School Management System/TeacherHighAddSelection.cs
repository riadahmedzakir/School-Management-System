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
    public partial class TeacherHighAddSelection : MetroFramework.Forms.MetroForm
    {
        private TeacherHigh aTab;
        public TeacherHighAddSelection(TeacherHigh a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighAddTeacher aSelection = new TeacherHighAddTeacher(this);
            aSelection.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHightAddStudent bSelection = new TeacherHightAddStudent(this);
            bSelection.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighAddParent cSelection = new TeacherHighAddParent(this);
            cSelection.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }
    }
}
