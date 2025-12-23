using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarrierLink
{
    public partial class EmpRegi : Form
    {
        public EmpRegi()
        {
            InitializeComponent();
        }
        users u1 = new users();
        skills s1 = new skills();
        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Full Name is required!");
                isValid = false;
            }
            else if (!Regex.IsMatch(textBox3.Text, @"^[A-Za-z\s]+$"))
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
                errorProvider1.SetError(textBox2, "Contact number is required!");
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
            if (isValid)
            {
                u1.fullName = textBox3.Text;
                u1.email = textBox1.Text;
                u1.contactNo = textBox2.Text;
                u1.userName = textBox4.Text;
                u1.password = textBox6.Text;
                u1.Qualification = textBox5.Text;

                s1.skillName = checkedListBox1.CheckedItems.ToString();

                bool success = u1.Insert(u1);
                bool success2 = s1.Insert(s1);

                if (success && success2)
                {
                    LoginPortal emp = new LoginPortal();
                    emp.Show();
                    this.Close();
                    MessageBox.Show("Employee details added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (success)
                {
                    MessageBox.Show("Employee details added successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Employee details are not added", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            foreach (int i in checkedListBox1.CheckedIndices.Cast<int>().ToList())
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPortal lp = new LoginPortal();
            lp.Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
