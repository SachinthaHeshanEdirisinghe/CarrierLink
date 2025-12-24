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
    public partial class JobForm : Form
    {
        string username;
        public JobForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        jobs js = new jobs();
        private void button3_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)//add job
        {
            NewJob nj = new NewJob(username);
            nj.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)//view
        {
            DataTable dt = js.select();
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)//matched job
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void JobForm_Load(object sender, EventArgs e)
        {
            DataTable dt = js.select();
            dataGridView1.DataSource = dt;
        }
    }
}
