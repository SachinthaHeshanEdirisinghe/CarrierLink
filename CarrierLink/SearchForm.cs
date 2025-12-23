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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        job_skills js = new job_skills();
        private void button1_Click(object sender, EventArgs e)//srch
        {
            string sql = comboBox1.Text;
            string sql2 = comboBox2.Text;
            string sql3 = comboBox3.Text;

            MySqlConnection conn = new MySqlConnection(mysql);
            conn.Open();
            string sql = "SELECT * FROM job_skills WHERE Name LIKE @search OR Gender LIKE @search";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@search", "%" + t + "%");
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
            UserProfile prof = new UserProfile();
            prof.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchForm srch = new SearchForm();
            srch.Show();
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
            DataTable dt = js.select();
            dataGridView1.DataSource = dt;
        }
    }
}
