using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.util
{
    internal class DBConnection
    {
            private static SqlConnection connection;

            // get connection
            public static SqlConnection GetConnection()
            {
                if (connection == null)
                {
                //create connection
                    connection = new SqlConnection(ReadConnectionStringFromFile("dbconfig.txt"));
                }

                return connection;
            }

            private static string ReadConnectionStringFromFile(string fileName)
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    if (lines.Length >= 4)
                    {
                        return $" Data Source = {lines[0]};Initial Catalog = {lines[1]};Integrated Security = {lines[2]};Trust Server Certificate = {lines[3]};";
                    }
                    else
                    {
                        throw new Exception("Invalid format for connection string file");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading connection string: {ex.Message}");
                    return null;
                }
            }
    }
}
