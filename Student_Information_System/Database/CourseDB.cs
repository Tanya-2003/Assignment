using System;
using System.Data.SqlClient;
using Student_Information_System.Models;


namespace Student_Information_System.Database
{
    public class CourseDB
    {
        public static void InsertCourse(int c_id, string c_name, string c_code, string instructor, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Courses (CourseId, CourseName, CourseCode, InstructorName) VALUES (@CourseId, @CourseName, @CourseCode, @InstructorName)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@CourseId", c_id);
                    command.Parameters.AddWithValue("@CourseName", c_name);
                    command.Parameters.AddWithValue("@CourseCode", c_code);
                    command.Parameters.AddWithValue("@InstructorName", instructor);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Course inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert course.");
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

        public static void UpdateCourse(int u_cid, string u_cname, string u_ccode, string u_instructor, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Courses SET CourseName = @CourseName, CourseCode = @CourseCode, InstructorName = @InstructorName WHERE CourseId = @CourseId";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@CourseId", u_cid);
                    command.Parameters.AddWithValue("@CourseName", u_cname);
                    command.Parameters.AddWithValue("@CourseCode", u_ccode);
                    command.Parameters.AddWithValue("@InstructorName", u_instructor);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Course updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No records updated.");
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


        public static void GetEnrollments(int courseId, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Enrollments WHERE CourseId = @CourseId";
                    SqlCommand command = new SqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@CourseId", courseId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Enrollment ID: {reader["EnrollmentId"]}, Student ID: {reader["StudentId"]}, Enrollment Date: {reader["EnrollmentDate"]}");
                    }
                    reader.Close();
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

        public static void GetTeacher(string courseName, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT TeacherName FROM Courses WHERE CourseName = @CourseName";
                    SqlCommand command = new SqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@CourseName", courseName);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        Console.WriteLine($"Instructor for course '{courseName}': {result}");
                    }
                    else
                    {
                        Console.WriteLine($"No instructor found for course '{courseName}'.");
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

        public static void DisplayRecords(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Courses";
                    SqlCommand command = new SqlCommand(selectQuery, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Course ID: {reader["CourseId"]}, Course Name: {reader["CourseName"]}, Course Code: {reader["CourseCode"]}, Instructor Name: {reader["InstructorName"]}");
                    }
                    reader.Close();
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

        public static void AssignTeacher(Teacher teachers, Course course2, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Courses SET InstructorName = @InstructorName WHERE CourseId = @CourseId";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@InstructorName", $"{teachers.FirstName} {teachers.LastName}");
                    command.Parameters.AddWithValue("@CourseId", course2.CourseID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Teacher assigned to the course successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Assignment failed.");
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
    }
}
