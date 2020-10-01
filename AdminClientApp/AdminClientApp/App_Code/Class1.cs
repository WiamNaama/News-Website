using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminClientApp.App_Code
{
    public class UserOperation
    {
        SqlDataReader reader;
        SqlConnection con;
        SqlCommand myCommand;
        public int login(string username, string pass)

        {
            //try
            //{
            string user_type = "";
            int x = 0;
            string mySql = "select * from Users where name = @name and password=@password";
            myCommand.Parameters.Clear();
            myCommand.Parameters.AddWithValue("@name", username);
            myCommand.Parameters.AddWithValue("@password", pass);
            myCommand.CommandText = mySql;
            con.Open();

            reader = myCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user_type = reader["Uid"].ToString();
                    x = int.Parse(user_type);

                }
            }

            return x;
        }
    }
}