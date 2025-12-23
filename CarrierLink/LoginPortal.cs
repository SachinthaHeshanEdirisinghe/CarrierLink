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

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == false)
            {
                errorProvider1.SetError(textBox1, "Invalid username!");
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text) || textBox2.Text == false)
            {
                errorProvider1.SetError(textBox1, "Invalid password!");
            }

            if ((string)comboBox1.SelectedItem == "Job Seeker")
            {
                EmpHome emp = new EmpHome();
                emp.Show();
            }
            else if ((string)comboBox1.SelectedItem == "Employer")
            {
                CompHome comp = new CompHome();
                comp.Show();
            }
            else
            {
                errorProvider1.SetError(comboBox1, "Select appropriate user type!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((string) comboBox1.SelectedItem == "Job Seeker")
            {
                EmpRegi emp = new EmpRegi();
                emp.Show();
            }
            else if ((string) comboBox1.SelectedItem == "Employer")
            {
                CompRegi comp = new CompRegi();
                comp.Show();
            }
            else
            {
                MessageBox.Show("Select appropriate user type!", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
