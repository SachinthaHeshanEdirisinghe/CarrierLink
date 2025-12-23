using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierLink
{
    internal class Employer
    {
        public int employerID { get; set; }
        public string companyName { get; set; }
        public string jobCategory { get; set; }
        public string companyLocation { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string email { get; set; }

        string mysqlconn = "server=127.0.0.1;database=carrierlink;user=root;password=;";

        public DataTable select()
        {
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM employers";
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

        public bool check(string username, string password)
        {
            string dbpass = "";
            bool isExist = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            string sql = "SELECT password FROM employers WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            conn.Open();
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                dbpass = result.ToString();
            }
            conn.Close();

            if (password.Equals(dbpass))
            {
                isExist = true;
            }

            return isExist;
        }

        public bool Insert(Employer u1)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            try
            {
                string sql = "INSERT INTO employers (companyName,jobCategory,username,password,companyLocation,email) VALUES (@companyName,@jobCategory,@username,@password,@companyLocation,@email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@companyName", u1.companyName);
                cmd.Parameters.AddWithValue("@jobCategory", u1.jobCategory);
                cmd.Parameters.AddWithValue("@username", u1.username);
                cmd.Parameters.AddWithValue("@password", u1.passwordHash);
                cmd.Parameters.AddWithValue("@companyLocation", u1.companyLocation);
                cmd.Parameters.AddWithValue("@email", u1.email);

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
