using System;
using System.Data.SqlClient;

namespace Student_Information_System.Database
{
    public class EnrollmentDB
    {
        public static void InsertEnrollment(int e_id, int s_id, int c_id, DateTime e_date, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Enrollments (EnrollmentId, StudentId, CourseId, EnrollmentDate) VALUES (@EnrollmentId, @StudentId, @CourseId, @EnrollmentDate)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@EnrollmentId", e_id);
                    command.Parameters.AddWithValue("@StudentId", s_id);
                    command.Parameters.AddWithValue("@CourseId", c_id);
                    command.Parameters.AddWithValue("@EnrollmentDate", e_date);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Enrollment inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Enrollment insertion failed.");
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static void GetStudent(int studentId, string connectionString)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Students WHERE StudentId = @StudentId";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        SqlDataReader reader = command.ExecuteReader();

                        // Process data
                        while (reader.Read())
                        {
                            Console.WriteLine($"Student ID: {reader["StudentId"]}, Name: {reader["FirstName"]} {reader["LastName"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        public static void GetCourse(int courseId, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Courses WHERE CourseId = @CourseId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Course ID: {reader["CourseId"]}, Name: {reader["CourseName"]}, Code: {reader["CourseCode"]}, Instructor: {reader["Instructor"]}");
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
                    string query = "SELECT * FROM Enrollments";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Enrollment ID: {reader["EnrollmentId"]}, Student ID: {reader["StudentId"]}, Course ID: {reader["CourseId"]}, Enrollment Date: {reader["EnrollmentDate"]}");
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
