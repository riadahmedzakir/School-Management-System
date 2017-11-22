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
    public partial class TeacherHighDeleteParent : MetroFramework.Forms.MetroForm
    {
        public TeacherHighDeleteParent()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //String query1 = "DELETE FROM `parents` WHERE `parents`.`P_ID` = '" + metroTextBox1.Text + "'";
            //String query2 = "DELETE FROM `prioritytable` WHERE `prioritytable`.`ID` = '" + metroTextBox1.Text + "'";

            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (metroTextBox1.Text == "")
            {
                MessageBox.Show("Delete Fail");
            }
            else
            {
                try
                {
                    cmd.CommandText = "DELETEPARENT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("A", OracleType.VarChar).Value = metroTextBox1.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful");
                    this.Close();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }               
            }
        }
    }
}
