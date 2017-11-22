using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;

namespace School_Management_System
{
    public partial class TeacherHightAddStudent : MetroFramework.Forms.MetroForm
    {
        private TeacherHighAddSelection aTab;
        public TeacherHightAddStudent(TeacherHighAddSelection a)
        {
            aTab = a;
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //String query1 = "INSERT INTO `students` (`S_ID`, `F_NAME`, `L_NAME`, `D_ID`, `GPA`, `CLASS`, `Priority`) VALUES('"+ metroTextBox1.Text +"', '"+ metroTextBox2.Text +"', '"+ metroTextBox3.Text +"', '"+ metroTextBox4.Text +"','"+ metroTextBox5.Text +"', '"+ Convert.ToDouble(metroTextBox6.Text) +"', '2')";
            // String query2 = "INSERT INTO `prioritytable` (`ID`, `Password`, `Priority`) VALUES ('" + metroTextBox1.Text + "', '" + metroTextBox7.Text + "', 2)";

            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            
            if (metroTextBox1.Text == null || metroTextBox2.Text == null || metroTextBox3.Text == null || metroTextBox4.Text == null || metroTextBox5.Text == null || metroTextBox6.Text == null || metroTextBox7.Text == null)
            {
                MessageBox.Show("Fill in all Form and try again");
            }
            else
            {
                try
                {
                    cmd.CommandText = "ADDSTUDENT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("A", OracleType.VarChar).Value = metroTextBox1.Text;
                    cmd.Parameters.Add("B", OracleType.VarChar).Value = metroTextBox2.Text;
                    cmd.Parameters.Add("C", OracleType.VarChar).Value = metroTextBox3.Text;
                    cmd.Parameters.Add("D", OracleType.VarChar).Value = metroTextBox4.Text;
                    cmd.Parameters.Add("E", OracleType.Number).Value = Convert.ToDouble(metroTextBox5.Text);
                    cmd.Parameters.Add("F", OracleType.Number).Value = Convert.ToDouble(metroTextBox6.Text);
                    cmd.Parameters.Add("G", OracleType.VarChar).Value = metroTextBox7.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User Registration Successful");
                    cmd.Dispose();
                    this.Close();
                    aTab.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fill All Fields");
                }
            }
        }

        private void TeacherHightAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
