using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   

namespace CarrierLink
{
    public partial class SearchForm : Form
    {
        string username;
        public SearchForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        Employer employer=new Employer();
        string mysql = "server=127.0.0.1;database=carrierlink;user=root;password=;";
        private void button1_Click(object sender, EventArgs e)//srch
        {
            
            string category = comboBox2.Text;
            string location = comboBox3.Text;

            MySqlConnection conn = new MySqlConnection(mysql);
            conn.Open();
            string query = "SELECT * FROM jobs inner join employers on jobs.employerID=employers.empId WHERE employers.jobCategory=@category OR jobs.location=@location";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@category",category);
            cmd.Parameters.AddWithValue("@location",location);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserProfile prof = new UserProfile(username);
            prof.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
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

        private void SearchForm_Load(object sender, EventArgs e)
        {
            jobs job=new jobs();
            DataTable dt = job.select();
            dataGridView1.DataSource = dt;
        }
    }
}
