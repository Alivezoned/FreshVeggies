using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.IO;

namespace FreshVeggies.Class
{
    public class LoginDatabase
    {
        SourceStrings strings = new SourceStrings();

        /// <summary>
        /// Register a new user with some user data
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="email">Email Id of the user</param>
        /// <param name="address">Physical Address of the user</param>
        /// <param name="pin">Pin Code</param>
        /// <param name="phone">Phone Number</param>
        /// <returns>Returns True if insertion is successful</returns>
        public Boolean Register(
            String Username, 
            String Password,
            String email,
            String address,
            String pin,
            String phone)
        {
            Boolean status = false;
            using (OleDbConnection c = new OleDbConnection(strings.DataSourceGlobal))
            {
                c.Open();
                using (OleDbCommand cmd = new OleDbCommand("insert into user_table ([username], [password], [email], [address], [pin_code], [phone_no]) values(@v1, @v2, @v3, @v4, @v5, @v6)", c))
                {
                    cmd.Parameters.AddWithValue("@v1", Username);
                    cmd.Parameters.AddWithValue("@v2", Password);
                    cmd.Parameters.AddWithValue("@v3", email);
                    cmd.Parameters.AddWithValue("@v4", address);
                    cmd.Parameters.AddWithValue("@v5", pin);
                    cmd.Parameters.AddWithValue("@v6", phone);
                    cmd.CommandType = System.Data.CommandType.Text;
                    int rowAffect = cmd.ExecuteNonQuery();
                    if (rowAffect > 0)
                    {
                        status = true;
                    }
                }
                c.Close();
            }
            return status;
        }

        /// <summary>
        /// Logs in with the Username and Password
        /// </summary>
        /// <param name="Username">The Username</param>
        /// <param name="Password">The Password</param>
        /// <returns>Returns "Username,Password" if login is successful</returns>
        public String Login(String Username, String Password)
        {
            String ReturnItem = "";
            String Query = "SELECT * FROM user_table WHERE username = '"+Username+"' AND password = '"+Password+"'";
            using (OleDbConnection c = new OleDbConnection(strings.DataSourceGlobal))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(Query, c);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReturnItem = reader.GetString(1) + "," + reader.GetString(2);
                    }
                    reader.Close();
                }
                c.Close();
            }
            return ReturnItem;
        }

        /// <summary>
        /// Checks if User Exists in the Table
        /// </summary>
        /// <param name="Username">The Username</param>
        /// <returns>Returns True if User Exists</returns>
        public Boolean CheckUserExists(String Username)
        {
            Boolean status = false;
            String Query = "SELECT * FROM user_table WHERE username = '"+Username+"'";
            using (OleDbConnection c = new OleDbConnection(strings.DataSourceGlobal))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(Query, c);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == Username)
                        {
                            status = true;
                        }
                    }
                    reader.Close();
                }
                c.Close();
            }
            return status;
        }

        /// <summary>
        /// Use this to Update OR Delete User Data
        /// </summary>
        /// <param name="query">Write the Database Query String</param>
        /// <returns>returns true if successful</returns>
        public Boolean UpdateUserData(String query)
        {
            Boolean status = false;
            using (OleDbConnection c = new OleDbConnection(strings.DataSourceGlobal))
            {
                c.Open();
                OleDbCommand cmd = new OleDbCommand(query, c);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    status = true;
                }
                c.Close();
            }
            return status;
        }
    }
}