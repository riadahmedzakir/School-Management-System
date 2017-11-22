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
    public partial class TeacherNorm : MetroFramework.Forms.MetroForm
    {

        private String userName;
        private String userID;
        private String birthDay;
        private String position;
        public TeacherNorm(String u)
        {
            InitializeComponent();
            userID = u.ToUpper();
            //MessageBox.Show(userID);

            DBConnect conn = new DBConnect();
            String query = "SELECT * FROM `teachers` WHERE `T_ID` =  '" + userID + "'";
            MySqlDataReader dr = conn.Select(query);

            while (dr.Read())
            {
                userName = Convert.ToString(dr["F_NAME"]) + " " + Convert.ToString(dr["L_NAME"]);
                birthDay = Convert.ToString(dr["DOB"]);
                position = Convert.ToString(dr["Position"]);
            }

            metroTextBox1.Text = "Logged in as, " + userName;
            metroTextBox2.Text = userName;
            metroTextBox3.Text = userID;
            metroTextBox4.Text = birthDay;
            metroTextBox5.Text = position;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage alogin = new LoginPage();
            alogin.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            TeacherNormAddNumber aSelection = new TeacherNormAddNumber();
            aSelection.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            TeacherNormChangePassword bSelection = new TeacherNormChangePassword(userID);
            bSelection.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            TeacherNormUpdateGPA cSelection = new TeacherNormUpdateGPA();
            cSelection.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherNormSchedule dSelection = new TeacherNormSchedule(this);
            dSelection.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherNormViewStudent eSelection = new TeacherNormViewStudent(this);
            eSelection.Show();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherNormSearchStudentByID fSelection = new TeacherNormSearchStudentByID(this);
            fSelection.Show();
        }
    }
}
