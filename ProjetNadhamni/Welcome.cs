using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetNadhamni
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }


        private void start_Click_1(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
