using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetNadhamni
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
        string working, job, student;

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dsh1 = new Dashboard();
            this.Hide();
            dsh1.Show();
        }

        private void btn_tasks_Click(object sender, EventArgs e)
        {
            Tasks tsk1 = new Tasks();
            this.Hide();
            tsk1.Show();
        }

        private void btn_statistics_Click(object sender, EventArgs e)
        {
            Statistics stc1 = new Statistics();
            this.Hide();
            stc1.Show();
        }

        private void btn_parameters_Click(object sender, EventArgs e)
        {
            Settings st1 = new Settings();
            this.Hide();
            st1.Show();
        }

        private void ExitDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.Show();
        }

        private void btn_planningProfile_Click(object sender, EventArgs e)
        {
            DailyPlanning dp2 = new DailyPlanning();
            this.Hide();
            dp2.Show();
        }

        private void Profile_Shown(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Data Source=DESKTOP-69MM1NJ\SQLEXPRESS;Initial Catalog=NadhamniDB;Integrated Security=True;Pooling=False";

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select FirstName from Profile where UserName='" + Home.FK + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txt_firstName.Text = dr[0].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            try
            {
                con.Open();
                string selectQuery = "select ProfilePic from Profile  where UserName = '" + Home.FK + "'";
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Byte[] img = (Byte[])(dr[0]);
                    if (img == null)
                    {
                        circularPic1.Image = null;
                    }

                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        circularPic1.Image = Image.FromStream(ms);

                    }
                }
                else
                {
                    MessageBox.Show("error img not found");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            try
            {
               
                con.Open();
                SqlCommand cmd = new SqlCommand("select Birthday,CivilStatus,Adress,TypeOfWork,Work,Student from Profile where UserName='" + Home.FK + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    
                    txt_Birth.Text = Convert.ToDateTime(dr[0]).ToShortDateString();
                    txt_Civil.Text = dr[1].ToString();
                    txt_adr.Text = dr[2].ToString();
                    
                    working= dr[3].ToString();
                    job = dr[4].ToString();
                    student = dr[5].ToString();
                 

                }
                dr.Close();
                if (student.Equals("no") && job.Equals("no"))
                {
                    txt_work.Enabled = false;
                    txt_dep.Enabled = false;
                    txt_establishmentJob.Enabled = false;
                    txt_levelStudies.Enabled = false;
                    txt_specialty.Enabled = false;
                    txt_estabSchool.Enabled = false;
                }

                else if (job.Equals("yes"))
                {
                    txt_levelStudies.Enabled = false;
                    txt_specialty.Enabled = false;
                    txt_estabSchool.Enabled = false;
                    SqlCommand cmd1 = new SqlCommand("select Department,Establishment from Job where UserName='" + Home.FK + "'", con);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    txt_work.Text = working;
                    while (dr1.Read())
                    {

                        txt_dep.Text = dr1[0].ToString();
                        txt_establishmentJob.Text = dr1[1].ToString(); ;



                    }
                    dr1.Close();
                }

                else
                {
                    txt_work.Enabled = false;
                    txt_dep.Enabled = false;
                    txt_establishmentJob.Enabled = false;
                    SqlCommand cmd2 = new SqlCommand("select LevelOfStudies,Speciality,Establishment from Studies where UserName='" + Home.FK + "'", con);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {

                        txt_levelStudies.Text = dr2[0].ToString();
                        txt_specialty.Text = dr2[1].ToString();
                        txt_estabSchool.Text = dr2[2].ToString(); 

                    }
                    dr2.Close();

                }


                
                


                }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
    }
}
