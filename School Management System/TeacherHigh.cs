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
    public partial class TeacherHigh : MetroFramework.Forms.MetroForm
    {
        private String userName;
        private String userID;
        private String birthDay;
        private String position;
        public TeacherHigh(string u)
        {
            InitializeComponent();
            userID = u.ToUpper();
            //MessageBox.Show(userID);

            DBConnect conn = new DBConnect();
            String query = "SELECT * FROM `teachers` WHERE `T_ID` =  '" + userID + "'";   
            MySqlDataReader dr = conn.Select(query);

            while (dr.Read())
            {
                userName = Convert.ToString(dr["F_NAME"]) + " " +  Convert.ToString(dr["L_NAME"]);
                birthDay = Convert.ToString(dr["DOB"]);
                position = Convert.ToString(dr["Position"]);
            }

            metroTextBox1.Text = "Logged in as, " + userName;
            metroTextBox2.Text = userName;
            metroTextBox3.Text = userID;
            metroTextBox4.Text = birthDay;
            metroTextBox5.Text = position;
            dr.Close();
        }

        private void TeacherHigh_Load(object sender, EventArgs e)
        {

        }
        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage alogin = new LoginPage();
            alogin.Show();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighAddSelection aSelection = new TeacherHighAddSelection(this);
            aSelection.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighDeleteSelection bSelection = new TeacherHighDeleteSelection(this);
            bSelection.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHighUpdateSelection cSelection = new TeacherHighUpdateSelection(this);
            cSelection.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherHightViewSelection dSelection = new TeacherHightViewSelection(this);
            dSelection.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            TeacherHighChangePassword eSelection = new TeacherHighChangePassword(this,userID);
            eSelection.Show();
        }
    }
}
