using System;
using System.Data;
using System.Data.SqlClient;
using Student_Information_System.Models;


namespace Student_Information_System.Database
{
    public class TeacherDB
    {
        public static void InsertDetails(Teacher teacher, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Teachers (TeacherId, FirstName, LastName, Email) VALUES (@TeacherId, @FirstName, @LastName, @Email)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@TeacherId", teacher.TeacherID);
                    command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                    command.Parameters.AddWithValue("@LastName", teacher.LastName);
                    command.Parameters.AddWithValue("@Email", teacher.Email);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Teacher record inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Teacher record insertion failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateTeacherInfo(Teacher teacher1, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Teachers SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE TeacherId = @TeacherId";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@TeacherId", teacher1.TeacherID);
                    command.Parameters.AddWithValue("@FirstName", teacher1.FirstName);
                    command.Parameters.AddWithValue("@LastName", teacher1.LastName);
                    command.Parameters.AddWithValue("@Email", teacher1.Email);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Teacher record updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No records updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void GetAssignedCourses(string teacherName, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string storedProcedureName = "GetAssignedCoursesForTeacher";
                    SqlCommand command = new SqlCommand(storedProcedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TeacherName", teacherName);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine($"Courses assigned to {teacherName}:");
                        while (reader.Read())
                        {
                            string courseName = reader["CourseName"].ToString();
                            Console.WriteLine(courseName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No courses assigned to {teacherName}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DisplayDetails(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Teachers";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Teacher ID: {reader["TeacherId"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Email: {reader["Email"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}