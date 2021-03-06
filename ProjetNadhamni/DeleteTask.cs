﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetNadhamni
{
    public partial class DeleteTask : Form
    {
        public DeleteTask()
        {
            InitializeComponent();
        }

        private void txt_deleteTask_Click(object sender, EventArgs e)
        {
            txt_deleteTask.Clear();
        }

        private void btn_DeleteTask_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Data Source=DESKTOP-69MM1NJ\SQLEXPRESS;Initial Catalog=NadhamniDB;Integrated Security=True;Pooling=False";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Tasks where Id=" + int.Parse(txt_deleteTask.Text), con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                this.Hide();
                SuccessDeleting sd = new SuccessDeleting() ;
                sd.Show();
                
            }
        }
    }
}
