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
    public partial class TeacherHighTeacherView : MetroFramework.Forms.MetroForm
    {
        private TeacherHightViewSelection aTab;
        public TeacherHighTeacherView(TeacherHightViewSelection a)
        {
            aTab = a;
            InitializeComponent();

            string oradb = "Data Source=XE; User Id=RIAD;Password=1133;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            //String query = "Select * from `teachers`";
            cmd.CommandText = "Select * from Teachers";
            cmd.CommandType = CommandType.Text;

            try
            {
                OracleDataAdapter sda = new OracleDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            aTab.Show();
        }
    }
}
