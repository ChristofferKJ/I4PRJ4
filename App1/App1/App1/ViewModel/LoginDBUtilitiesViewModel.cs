using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using App1.Model;


namespace App1.ViewModel
{
    class LoginDBUtilitiesViewModel
    {
        public LoginDBUtilitiesViewModel()
        { }

        private SqlConnection openConnection // Open connection to database
        {
            get
            {
                var con = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=E18I4DABau570382;Persist Security Info=True;" +
                                            "User ID=E18I4DABau570382;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;" +
                                            "Encrypt=False;TrustServerCertificate=True");
                con.Open();
                return con;
            }
        }

        public void AddUserDB(ref User u)  // add a User
        {
            string insertStringParam = @"INSERT INTO [User] (Username, Password)
                                                    OUTPUT INSERTED.UserID  
                                                    VALUES (@Username, @Password)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                // Get your parameters ready                    
                cmd.Parameters.AddWithValue("@Username", u.Username);
                cmd.Parameters.AddWithValue("@Password", u.Password);

                u.UserID = (int)cmd.ExecuteScalar();
            }
        }

        public void UpdateUserDB(ref User u)  // Update an existing user
        {
            string updateStringParam = @"UPDATE User 
                                             SET Username=@Username, Password=@Password
                                             WHERE UserID=@UserID";

            using (SqlCommand cmd = new SqlCommand(updateStringParam, openConnection))
            {
                // Get your parameters ready                    
                cmd.Parameters.AddWithValue("@Username", u.Username);
                cmd.Parameters.AddWithValue("@Password", u.Password);

                var id = (long)cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUserDB(ref User u)  // Delete an existing user, from UserID
        {
            string deleteString = @"DELETE FROM User WHERE (UserID = @UserID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", u.UserID);

                var id = (long)cmd.ExecuteNonQuery();
                u = null;
            }
        }

        public void GetUserByUsername(ref User u)// Show user, from UserID
        {
            string sqlcmd = @"SELECT [UserID], [Password] FROM User WHERE ([Username] = @Username)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@Username", u.Username);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    u.UserID = (int)rdr["UserID"];
                }
            }
        }

        public List<User> GetUsers() // Prints a list of all the existing users
        {
            string sqlcmd = @"SELECT * FROM User";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                List<User> Userlist = new List<User>();
                User u = null;
                while (rdr.Read())
                {
                    u = new User(_username: "", _password: "");
                    u.UserID = (int)rdr["UserID"];
                    u.Username = (string)rdr["Username"];
                    u.Password = (string)rdr["Password"];

                    Userlist.Add(u);
                }
                return Userlist;
            }
        }

    }
}
