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

namespace School_Management_System
{
    public partial class ParentFinancialView : MetroFramework.Forms.MetroForm
    {
        private Parent aTab;
        public ParentFinancialView(Parent a)
        {
            aTab = a;
            InitializeComponent();

            DBConnect conn = new DBConnect();

            String query = "Select * from `uniqueparentfinancial`";
            conn.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnectionString());

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
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
