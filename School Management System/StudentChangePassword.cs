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
    public partial class StudentChangePassword : MetroFramework.Forms.MetroForm
    {
        private String userID;
        private String passWord;
        public StudentChangePassword(String u)
        {
            userID = u;
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "UPDATEPASSWORD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OLDPASS", OracleType.VarChar).Value = metroTextBox1.Text;
            cmd.Parameters.Add("NEWPASS", OracleType.VarChar).Value = metroTextBox2.Text;
            cmd.Parameters.Add("CONFIRMPASS", OracleType.VarChar).Value = metroTextBox3.Text;
            cmd.Parameters.Add("A", OracleType.VarChar).Value = userID;
            cmd.Parameters.Add("return_value", OracleType.Number).Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            int a = Convert.ToInt32(cmd.Parameters["return_value"].Value.ToString());

            if (a == 1)
            {
                MessageBox.Show("Password Changed Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not change Password, Try Again");
            }
        }
    }
}
