using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarrierLink
{
    internal class jobs
    {
        public int jobID {  get; set; }
        public int employerID { get; set; }
        public string jobTitle { get; set; }
        public string description { get; set; }
        public string salaryRange { get; set; }
        public string location { get; set; }
        public string skill {  get; set; }

        string mysqlconn = "server=127.0.0.1;database=carrierlink;user=root;password=;";

        public DataTable select()
        {
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM jobs";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                conn.Open();
                adp.Fill(dt);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public int GetEmployerID(string username) {
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            int empId=-1;
            MessageBox.Show(username);
            try
            {
                string sql = "select empId from employers where username=@username";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@username", username);


                conn.Open();
                Object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    empId = Convert.ToInt32(result);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
                conn.Close();
                
            }
            return empId;
        }

        public bool Insert(jobs j1,string username)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            MessageBox.Show(j1.GetEmployerID(username).ToString());

            try
            {
                string sql = "INSERT INTO jobs(empId,jobTitle,description,salaryRange,location,skill)" +
                    "VALUES(@empId,@jobTitle,@description,@salaryRange,@location,@skill)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@empId", j1.GetEmployerID(username));
                cmd.Parameters.AddWithValue("@jobTitle", j1.jobTitle);
                cmd.Parameters.AddWithValue("@description", j1.description);
                cmd.Parameters.AddWithValue("@salaryRange", j1.salaryRange);
                cmd.Parameters.AddWithValue("@location", j1.location);
                cmd.Parameters.AddWithValue("@skill", j1.skill);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }


    }
}
