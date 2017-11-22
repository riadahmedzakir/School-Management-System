using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace School_Management_System
{
    public partial class TeacherHighAddParent : MetroFramework.Forms.MetroForm
    {
        private TeacherHighAddSelection aTab;
        public TeacherHighAddParent(TeacherHighAddSelection a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //String query1 = "INSERT INTO `parents` (`P_ID`, `F_NAME`, `L_NAME`, `Priority`) VALUES('"+ metroTextBox1.Text +"', '"+ metroTextBox2.Text +"', '"+ metroTextBox3.Text +"','3')";
            //String query2 = "INSERT INTO `prioritytable` (`ID`, `Password`, `Priority`) VALUES ('" + metroTextBox1.Text + "', '" + metroTextBox4.Text + "', 3)";

            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            if (metroTextBox1.Text == null || metroTextBox2.Text == null || metroTextBox3.Text == null || metroTextBox4.Text == null)
            {
                MessageBox.Show("Fill in all Form and try again");
            }
            else
            {
                try
                {
                    cmd.CommandText = "ADDPARENT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("A", OracleType.VarChar).Value = metroTextBox1.Text;
                    cmd.Parameters.Add("B", OracleType.VarChar).Value = metroTextBox2.Text;
                    cmd.Parameters.Add("C", OracleType.VarChar).Value = metroTextBox3.Text;
                    cmd.Parameters.Add("D", OracleType.VarChar).Value = metroTextBox4.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Registration Successful");
                    this.Close();
                    aTab.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fill All Fields");
                }
            }
        }
    }
}
