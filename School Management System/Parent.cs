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
    public partial class Parent : MetroFramework.Forms.MetroForm
    {
        private String userName;
        private String userID;
        private String birthDay;
        public Parent(String u)
        {
            InitializeComponent();

            userID = u;

            DBConnect conn = new DBConnect();
            String query = "SELECT * FROM `parents` WHERE `P_ID` =  '" + userID + "'";
            MySqlDataReader dr = conn.Select(query);

            while (dr.Read())
            {
                userName = Convert.ToString(dr["F_NAME"]) + " " + Convert.ToString(dr["L_NAME"]);
                birthDay = Convert.ToString(dr["DOB"]);
            }

            metroTextBox1.Text = "Logged in as, " + userName;
            metroTextBox2.Text = userName;
            metroTextBox3.Text = userID;
            metroTextBox4.Text = birthDay;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage alogin = new LoginPage();
            alogin.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParentStudentMarks aSelection = new ParentStudentMarks(this);
            aSelection.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParentFinancialView bSelection = new ParentFinancialView(this);
            bSelection.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            StudentChangePassword cSelection = new StudentChangePassword(userID);
            cSelection.Show();
        }
    }
}
