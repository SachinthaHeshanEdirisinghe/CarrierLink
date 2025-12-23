using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierLink
{
    internal class users
    {
        public int userID {  get; set; }
        public string userType { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string Qualification { get; set; }
        public string fullName { get; set; }
        public string companyName { get; set; }
        public string companyLocation { get; set; }
        public string jobCategory { get; set; }

        string mysqlconn = "server=127.0.0.1;database=it2143;user=root;password=;";

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

        public bool Insert(users u1)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(mysqlconn);

            try
            {
                string sql = "INSERT INTO users(userID,userType,userName,passwordHash,email,contactNo,Qualification" +
                    ",userID,userType,userName,passwordHash,email,contactNo,Qualification)" +
                    "VALUES(@userID,@userType,@userName,@passwordHash,@email,@contactNo,@Qualification,"+
                    "@userID,@userType,@userName,@passwordHash,@email,@contactNo,@Qualification)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@userType", u1.userType);
                cmd.Parameters.AddWithValue("@userName", u1.userName);
                cmd.Parameters.AddWithValue("@passwordHash", u1.passwordHash);
                cmd.Parameters.AddWithValue("@email", u1.email);
                cmd.Parameters.AddWithValue("@contactNo", u1.contactNo);
                cmd.Parameters.AddWithValue("@Qualification", u1.Qualification);
                cmd.Parameters.AddWithValue("@fullName", u1.fullName);
                cmd.Parameters.AddWithValue("@companyName", u1.companyName);
                cmd.Parameters.AddWithValue("@companyLocation", u1.companyLocation);
                cmd.Parameters.AddWithValue("@jobCategory", u1.jobCategory);

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
