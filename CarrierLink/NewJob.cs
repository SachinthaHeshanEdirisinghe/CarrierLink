using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarrierLink
{
    public partial class NewJob : Form
    {
        string username;
        public NewJob(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        jobs js = new jobs();
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.SelectedItem = null;
            textBox4.Text = "";
            foreach (int i in checkedListBox1.CheckedIndices.Cast<int>().ToList())
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPortal login = new LoginPortal();
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//post job
        {
            bool isvalid = true;


            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Job Title is required!");
                isvalid = false;
            }
            else if (!Regex.IsMatch(textBox1.Text, @"^[A-Za-z\s]+$"))
            {
                errorProvider1.SetError(textBox1, "Job Title must contain only letters!");
                isvalid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Job Desciption is required!");
                isvalid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Salary Range is required!");
                isvalid = false;
            }

            if (comboBox3.SelectedItem ==null)
            {
                errorProvider1.SetError(comboBox3, "Job Location is required!");
                isvalid = false;
            }
            if (isvalid)
            {

                List<string> selectedItems = new List<string>();

                foreach (var item in checkedListBox1.CheckedItems)
                {
                    selectedItems.Add(item.ToString());
                }

                string result = string.Join(", ", selectedItems);
                MessageBox.Show(result);
                js.jobTitle = textBox1.Text;
                js.description = textBox2.Text;
                js.salaryRange = textBox4.Text;
                js.location = comboBox3.SelectedItem.ToString();
                js.skill = result;
                bool success = js.Insert(js, username);

                if (success)
                {
                    MessageBox.Show("Job added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    JobForm jb = new JobForm(username);
                    jb.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Job Failed", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

                
                
            }
        }

        private void button5_Click(object sender, EventArgs e)//add job
        {
            //this.Open();
        }

        private void button6_Click(object sender, EventArgs e)//view job
        {
            JobForm jb = new JobForm(username);
            jb.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)//matched job
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            CompHome login = new CompHome(username);
            login.Show();
            this.Close();
        }
    }
}
