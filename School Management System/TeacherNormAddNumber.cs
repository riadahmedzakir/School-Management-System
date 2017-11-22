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
    public partial class TeacherNormAddNumber : MetroFramework.Forms.MetroForm
    {
        public TeacherNormAddNumber()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "UPDATEMARKS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("A", OracleType.VarChar).Value = metroTextBox1.Text;
                cmd.Parameters.Add("B", OracleType.Number).Value = Convert.ToDouble(metroTextBox2.Text);
                cmd.Parameters.Add("C", OracleType.Number).Value = Convert.ToDouble(metroTextBox2.Text);
                cmd.Parameters.Add("D", OracleType.Number).Value = Convert.ToDouble(metroTextBox2.Text);
                cmd.Parameters.Add("E", OracleType.Number).Value = Convert.ToDouble(metroTextBox2.Text);
                cmd.Parameters.Add("F", OracleType.Number).Value = Convert.ToDouble(metroTextBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Marks Updated");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }
    }
}
