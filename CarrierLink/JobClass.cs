using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        string mysqlconn = "server=127.0.0.1;database=it2143;user=root;password=;";

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

        public bool Insert(jobs j1)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            try
            {
                string sql = "INSERT INTO jobs(employerID,jobTitle,description,salaryRange,location)" +
                    "VALUES(@employerID,@jobTitle,@description,@salaryRange,@location)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@employerID", j1.employerID);
                cmd.Parameters.AddWithValue("@jobTitle", j1.jobTitle);
                cmd.Parameters.AddWithValue("@description", j1.description);
                cmd.Parameters.AddWithValue("@salaryRange", j1.salaryRange);
                cmd.Parameters.AddWithValue("@location", j1.location);


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
