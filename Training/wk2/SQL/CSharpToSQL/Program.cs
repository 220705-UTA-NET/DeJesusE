using System;
using System.Data.SqlClient;

namespace SQLProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Creating a School ...");
            // Student st1 = new Student(3, "Ellery", "109 Danton", "Some City", "Some state", 22222, "ellery@gmail.com", "(123)456-7890", 24);

            // Establish a connection
            string connectionString = "[REDACTED: No Stealy]";
            SqlConnection connection = new SqlConnection(connectionString);

            // Open connection so we can send commands to it
            connection.Open();

            // Inserting an entry into a table
            string cmdText = "SELECT * FROM dbo.Pokemon;";
            string insertText = @"INSERT INTO Pokemon (Name, Weight, Height)
                                  VALUES
                                  (@Name, @Weight, @Height);";
            // The @ in front of variables helps to protect against SQL Injections

            using (SqlCommand insertCmd = new SqlCommand(insertText, connection))
            {
                insertCmd.Parameters.AddWithValue("@Name", "Ditto");
                insertCmd.Parameters.AddWithValue("@Weight", 20);
                insertCmd.Parameters.AddWithValue("@Height", 20);

                insertCmd.ExecuteNonQuery();
            }



            // Printing entries from table
            // using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Customer;", connection)){ ... }
            // we can use a string as a parameter of the SqlCommand

            using (SqlCommand cmd = new SqlCommand(cmdText, connection))
            {
                // cmd.ExecuteNonQuery();

                // we can use a SqlDataReader to read the result
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(0) + ": " + reader.GetString(1) + " " + reader.GetInt32(2));
                    }
                }
            }



            connection.Close();


        }
    }
}