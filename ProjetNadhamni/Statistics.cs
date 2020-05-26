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
    public partial class Statistics : Form
    {
        public static bool svisited = false;
        public Statistics()
        {
            InitializeComponent();
            svisited = true;
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            Dashboard dsh3 = new Dashboard();
            this.Hide();
            dsh3.Show();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            Profile pf3 = new Profile();
            this.Hide();
            pf3.Show();
        }

        private void btn_tasks_Click(object sender, EventArgs e)
        {
            Tasks tsk3 = new Tasks();
            this.Hide();
            tsk3.Show();
        }

        private void btn_parameters_Click(object sender, EventArgs e)
        {
            Settings st3 = new Settings();
            this.Hide();
            st3.Show();
        }

        private void ExitDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w = new Welcome();
            w.Show();
        }

        private void btn_planningStat_Click(object sender, EventArgs e)
        {
            DailyPlanning dp4 = new DailyPlanning();
            this.Hide();
            dp4.Show();
        }

        private void Statistics_Shown(object sender, EventArgs e)
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

        }

        private void Statistics_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}
