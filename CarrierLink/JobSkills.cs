using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarrierLink
{
    internal class job_skills
    {
        public int jobID {  get; set; }
        public int skillID { get; set; }
        public int jobSkillID { get; set; }

        string mysqlconn = "server=127.0.0.1;database=it2143;user=root;password=;";

        public DataTable select()
        {
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM job_skills";
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

        public bool Insert(job_skills js1)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            try
            {
                string sql = "INSERT INTO jobs(jobID,skillID)" +
                    "VALUES(@jobID,@skillID)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@jobID", js1.jobID);
                cmd.Parameters.AddWithValue("@skillID", js1.skillID);
                

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
