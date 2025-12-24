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
    public partial class EmpHome : Form
    {
        
        string username;
        public EmpHome(string username)
        {
            InitializeComponent();
            this.username=username;
        }

        private void button1_Click(object sender, EventArgs e)//Find job
        {
            SearchForm srch = new SearchForm(username);
            srch.Show();
        }

        private void button6_Click(object sender, EventArgs e)//srch job
        {
            SearchForm srch = new SearchForm(username);
            srch.Show();
        }

        private void button3_Click(object sender, EventArgs e)//view match
        {

        }

        private void button7_Click(object sender, EventArgs e)//matchd job
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserProfile prof = new UserProfile(username);
            prof.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserProfile prof = new UserProfile(username);
            prof.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void EmpHome_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome , "+username +" !";
        }
    }
}
