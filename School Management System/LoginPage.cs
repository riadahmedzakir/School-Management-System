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
    public partial class LoginPage : MetroFramework.Forms.MetroForm
    {
        private String UserName;
        private String Password;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
             //UserName = metroTextBox1.Text;
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            //Password = metroTextBox2.Text;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM prioritytable WHERE ID = '" + metroTextBox1.Text + "' AND Password = '" + metroTextBox2.Text + "'";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                int priority = -1;

                while (dr.Read())
                {
                    UserName = Convert.ToString(dr.GetString(0));
                    Password = Convert.ToString(dr.GetString(1));
                    priority = Convert.ToInt32(dr.GetValue(2));
                }

                if (UserName == metroTextBox1.Text && Password == metroTextBox2.Text)
                {
                    switch (priority)
                    {
                        case 0:
                            TeacherHigh aTeacher = new TeacherHigh(UserName);
                            this.Hide();
                            aTeacher.Show();
                            break;
                        case 1:
                            TeacherNorm bTeacher = new TeacherNorm(UserName);
                            this.Hide();
                            bTeacher.Show();
                            break;
                        case 2:
                            Student aStudent = new Student(UserName);
                            this.Hide();
                            aStudent.Show();
                            break;
                        case 3:
                            Parent aParent = new Parent(UserName);
                            this.Hide();
                            aParent.Show();
                            break;
                    }
                    //MessageBox.Show("Correct");
                }
                else
                {
                    MessageBox.Show("Incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            this.Hide();
            FilterDemoPage dSelection = new FilterDemoPage(this);
            dSelection.Show();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReportDemoPage fSelection = new ReportDemoPage(this);
            fSelection.Show();
        }
    }
}
