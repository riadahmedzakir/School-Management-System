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
    public partial class TeacherNormUpdateGPA : MetroFramework.Forms.MetroForm
    {
        public TeacherNormUpdateGPA()
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

            //String query = "UPDATE `students` SET `GPA` = '" + metroTextBox2.Text + "' WHERE `students`.`S_ID` = '" + metroTextBox1.Text + "'";
            cmd.CommandText = "UPDATEGPA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("A", OracleType.VarChar).Value = metroTextBox1.Text;
            cmd.Parameters.Add("B", OracleType.VarChar).Value = Convert.ToDouble(metroTextBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("GPA updated Successfully");
            this.Close();
        }
    }
}
