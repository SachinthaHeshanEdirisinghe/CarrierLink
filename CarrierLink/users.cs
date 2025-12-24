using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarrierLink
{
    public class users
    {
        public int userID {  get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string Qualification { get; set; }
        public string fullName { get; set; }
        public string skill { get; set; }

        string mysqlconn = "server=127.0.0.1;database=carrierlink;user=root;password=;";
        public void getUser(string username)
        {
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM users  WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                conn.Open();
                adp.Fill(dt);
                userName = dt.Rows[0]["userName"].ToString();
                email= dt.Rows[0]["email"].ToString();
                contactNo = dt.Rows[0]["contactNo"].ToString() ;
                Qualification= dt.Rows[0]["Qualification"].ToString();
                fullName= dt.Rows[0]["fullName"].ToString();
                skill= dt.Rows[0]["skill"].ToString();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }

        }

        public DataTable select()
        {
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM users";
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

        public bool check(string username,string password)
        {
            string dbpass = "";
            bool isExist = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);
            
            string sql = "SELECT password FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            conn.Open();
            object result = cmd.ExecuteScalar();

            if (result != null) {
                dbpass = result.ToString();
            }
            conn.Close();

            if (password.Equals(dbpass)) { 
                isExist = true;
            }

            return isExist;
        }

        public bool Insert(users u1)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            try
            {
                string sql = @"INSERT INTO users (userName, password, email, contactNo, Qualification,fullName,skill) VALUES (@userName, @password, @email, @contactNo, @Qualification,@fullName,@skill)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@userName", u1.userName);
                cmd.Parameters.AddWithValue("@password", u1.password);
                cmd.Parameters.AddWithValue("@email", u1.email);
                cmd.Parameters.AddWithValue("@contactNo", u1.contactNo);
                cmd.Parameters.AddWithValue("@Qualification", u1.Qualification);
                cmd.Parameters.AddWithValue("@fullName", u1.fullName);
                cmd.Parameters.AddWithValue("@skill", u1.skill);

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
