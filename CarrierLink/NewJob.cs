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

namespace CarrierLink
{
    public partial class NewJob : Form
    {
        public NewJob()
        {
            InitializeComponent();
        }
        jobs js = new jobs();
        skills skills = new skills();
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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

            js.jobTitle = textBox1.Text;
            js.description = textBox2.Text;
            js.salaryRange = textBox4.Text;
            js.location = textBox3.Text;

            skills.skillName = checkedListBox1.CheckedItems.ToString();

            bool success = js.Insert(js);
            bool success2 = skills.Insert(skills);

            if (success && success2)
            {
                MessageBox.Show("Employee details added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (success)
            {
                MessageBox.Show("Employee details added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Job Title is required!");
            }
            else if (!Regex.IsMatch(textBox1.Text, @"^[A-Za-z\s]+$"))
            {
                errorProvider1.SetError(textBox1, "Job Title must contain only letters!");
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Job Desciption is required!");
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Salary Range is required!");
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Job Location is required!");
            }

            JobForm jb = new JobForm();
            jb.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)//add job
        {
            this.Open();
        }

        private void button6_Click(object sender, EventArgs e)//view job
        {
            JobForm jb = new JobForm();
            jb.Show();
            this.Close();
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
    }
}
