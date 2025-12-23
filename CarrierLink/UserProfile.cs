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
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//edit prof
        {

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserProfile prof = new UserProfile();
            prof.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchForm srch = new SearchForm();
            srch.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)//mtchd job
        {
            SearchForm srch = new SearchForm();
            srch.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }
    }
}
