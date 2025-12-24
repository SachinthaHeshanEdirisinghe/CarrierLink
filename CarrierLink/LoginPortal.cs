using Mysqlx;
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
    public partial class LoginPortal : Form
    {
        public LoginPortal()
        {
            InitializeComponent();
        }
        users u1 = new users();
        Employer e1= new Employer();
        private void button1_Click(object sender, EventArgs e)
        {
            string username="";
            string password="";

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Invalid username!");
            }
            else
            {
                username = textBox1.Text;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Invalid password!");
            }
            else
            {
                password = textBox2.Text;
            }

            if ((string)comboBox1.SelectedItem == "Job Seeker")
            {
                if (username != "" && password != "")
                {
                    if (u1.check(username, password))
                    {
                        EmpHome emp=new EmpHome(username);
                        emp.Show(); 
                        this.Hide();
                    }
                }

            }
            else if ((string)comboBox1.SelectedItem == "Employer")
            {
                if (username != "" && password != "")
                {
                    if (e1.check(username, password))
                    {
                        CompHome comp=new CompHome(username);
                        comp.Show();
                        this.Hide();
                    }

                }
            }
                else
                {
                    errorProvider1.SetError(comboBox1, "Select appropriate user type!");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmpOrComp empOrComp = new EmpOrComp();
            empOrComp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
