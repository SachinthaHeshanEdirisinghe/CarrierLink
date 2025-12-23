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
    public partial class CompRegi : Form
    {
        public CompRegi()
        {
            InitializeComponent();
        }
        Employer u1 = new Employer();
        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    errorProvider1.SetError(textBox3, "Company Name is required!");
                    isValid = false;
                }
                else if(!Regex.IsMatch(textBox3.Text, @"^[A-Za-z\s]+$"))
                {
                    errorProvider1.SetError(textBox3, "Name must contain only letters!");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Email is required!");
                    isValid = false;
                }
                else if (!Regex.IsMatch(textBox1.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    errorProvider1.SetError(textBox1, "Email must follow example@domain.com pattern.");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    errorProvider1.SetError(textBox2, "Job Category is required!");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    errorProvider1.SetError(textBox4, "Username is required!");
                    isValid = false;
                }
                else if (false)
                {
                    errorProvider1.SetError(textBox4, "Username already exist!");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    errorProvider1.SetError(textBox6, "Password is required!");
                    isValid = false;
                }

                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    errorProvider1.SetError(textBox5, "Company location is required!");
                    isValid = false;
                }
                if (isValid)
                {
                        u1.companyName = textBox3.Text;
                        u1.email = textBox1.Text;
                        u1.jobCategory = textBox2.Text;
                        u1.username = textBox4.Text;
                        u1.passwordHash = textBox6.Text;
                        u1.companyLocation = textBox5.Text;

                    bool success = u1.Insert(u1);
                    if (success)
                    {
                        LoginPortal comp = new LoginPortal();
                        comp.Show();
                        this.Close();
                        MessageBox.Show("Employer details added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Employer details are not added", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPortal lp = new LoginPortal(); 
            lp.Show();
            this.Close();
        }
    }
}
