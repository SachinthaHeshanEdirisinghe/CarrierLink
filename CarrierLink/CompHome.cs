using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarrierLink
{
    public partial class CompHome : Form
    {
        
        string username;
        public CompHome(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewJob job = new NewJob(username);
            job.Show();
        }

        private void button3_Click(object sender, EventArgs e)//job posting
        {
            JobForm jb = new JobForm(username);
            jb.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)//view job
        {
            JobForm jb = new JobForm(username);
            jb.Show();
        }

        private void button2_Click(object sender, EventArgs e)//find candidate
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployerProfile prof = new EmployerProfile(username);
            prof.Show();
        }

        private void button7_Click(object sender, EventArgs e)//mtchd job
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void CompHome_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome, " + username + " !";
        }
    }
}
