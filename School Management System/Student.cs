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
    public partial class Student : MetroFramework.Forms.MetroForm
    {
        private String userName;
        private String userID;
        private String birthDay;
        private int departmentID;
        private int Class;
        private double cgpa;
        public Student(String u)
        {
            InitializeComponent();
            userID = u;

            DBConnect conn = new DBConnect();
            String query = "SELECT * FROM `students` WHERE `S_ID` =  '" + userID + "'"; ;
            MySqlDataReader dr = conn.Select(query);

            while (dr.Read())
            {
                userName = Convert.ToString(dr["F_NAME"]) + " " + Convert.ToString(dr["L_NAME"]);
                birthDay = Convert.ToString(dr["DOB"]);
                departmentID = Convert.ToInt32(dr["D_ID"]);
                Class = Convert.ToInt32(dr["CLASS"]);
                cgpa = Convert.ToDouble(dr["GPA"]);
            }

            metroTextBox1.Text = "Logged in as, " + userName;
            metroTextBox2.Text = userName;
            metroTextBox3.Text = userID;
            metroTextBox4.Text = birthDay;
            //MessageBox.Show(Convert.ToString(departmentID));
            if (departmentID == 1)
            {
                metroTextBox5.Text = "SCIENCE";
            }
            else if(departmentID == 2)
            {
                metroTextBox5.Text = "COMMERCE";
            }
            else if(departmentID == 3)
            {
                metroTextBox5.Text = "ARTS";
            }
            metroTextBox6.Text = Convert.ToString(Class);
            metroTextBox7.Text = Convert.ToString(cgpa);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage alogin = new LoginPage();
            alogin.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSchedule aSelection = new StudentSchedule(this);
            aSelection.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentsExamSchedule bSelection = new StudentsExamSchedule(this);
            bSelection.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            StudentChangePassword cSelection = new StudentChangePassword(userID);
            cSelection.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentApplicationUC dSelection = new StudentApplicationUC(this, userID);
            dSelection.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentViewNumber eSelection = new StudentViewNumber(this);
            eSelection.Show();
        }
    }
}
