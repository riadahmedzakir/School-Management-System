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
    public partial class StudentApplicationUC : MetroFramework.Forms.MetroForm
    {
        private Student aTab;
        private string userID;
        public StudentApplicationUC(Student a, string u)
        {
            aTab = a;
            userID = u;
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }

        private void StudentApplicationUC_Load(object sender, EventArgs e)
        {
            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "SELECT * FROM RESULT WHERE S_ID='" + userID + "'"; ;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();

                metroTextBox1.Text = dr.GetValue(0).ToString();
                metroTextBox2.Text = dr.GetValue(4).ToString();
                metroTextBox3.Text = dr.GetValue(5).ToString();
                metroTextBox4.Text = dr.GetValue(2).ToString();
                metroTextBox5.Text = dr.GetValue(3).ToString();
                metroTextBox6.Text = dr.GetValue(2).ToString();
                metroTextBox7.Text = dr.GetValue(6).ToString();
                metroTextBox8.Text = dr.GetValue(7).ToString();
                metroTextBox9.Text = dr.GetValue(8).ToString();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
