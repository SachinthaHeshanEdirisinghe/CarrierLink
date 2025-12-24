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
        
        string username;
        public UserProfile(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        public UserProfile(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//edit prof
        {

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchForm srch = new SearchForm(username);
            srch.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)//mtchd job
        {
            SearchForm srch = new SearchForm(username);
            srch.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            users u1=new users();
            u1.getUser(username);
            fname.Text = u1.fullName;
            email.Text = u1.email;
            contactnum.Text=u1.contactNo;
            qualificationbox.Items.Add(u1.Qualification);
            skillbox.Items.Add(u1.skill);

        }
    }
}
