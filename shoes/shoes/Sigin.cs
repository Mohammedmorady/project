using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoes
{
    public partial class Sigin : Form
    {
        public Sigin()
        {
            InitializeComponent();
        }

        private void Sigin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUP signUP = new SignUP();
            this.Hide();
            signUP.ShowDialog();
            this.Close();
           
        }
    }
}
