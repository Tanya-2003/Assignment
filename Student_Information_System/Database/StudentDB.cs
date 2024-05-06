using System;
using System.Data.SqlClient;

namespace Student_Information_System.Database
{
    public class StudentDB
    {
        private readonly string connectionString;

        public StudentDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

    public static void InsertStudent(int id, string fname, string lname, string dob, string email, string phno, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Students (Id, FirstName, LastName, DateOfBirth, Email, PhoneNumber) VALUES (@Id, @FirstName, @LastName, @DateOfBirth, @Email, @PhoneNumber)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@FirstName", fname);
                    command.Parameters.AddWithValue("@LastName", lname);
                    command.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(dob));
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phno);

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter correct data format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    public static void UpdateStudent(int u_id, string u_fname, string u_lname, string u_dob, string u_email, string u_phno, string connectionString)
        {
            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Id", u_id);
                    command.Parameters.AddWithValue("@FirstName", u_fname);
                    command.Parameters.AddWithValue("@LastName", u_lname);
                    command.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(u_dob));
                    command.Parameters.AddWithValue("@Email", u_email);
                    command.Parameters.AddWithValue("@PhoneNumber", u_phno);

                    int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Record updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No records updated.");
                        }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter correct data format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    public static void Enroll(int c_id, int s_id, int e_id, string e_date, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Enrollment (CourseID, StudentID, EnrollmentID, EnrollmentDate) VALUES (@CourseID, @StudentID, @EnrollmentID, @EnrollmentDate)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@CourseID", c_id);
                    command.Parameters.AddWithValue("@StudentID", s_id);
                    command.Parameters.AddWithValue("@EnrollmentID", e_id);
                    command.Parameters.AddWithValue("@EnrollmentDate", DateTime.Parse(e_date));

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student enrolled in the course successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Enrollment failed.");
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

    public static void RecordPayment(int p_id, int studentid, decimal amount, string p_date, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Payments (PaymentId, StudentId, Amount, PaymentDate) VALUES (@PaymentId, @StudentId, @Amount, @PaymentDate)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@PaymentId", p_id);
                    command.Parameters.AddWithValue("@StudentId", studentid);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Parse(p_date));

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Payment recorded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Payment recording failed.");
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter correct data format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    public static void DisplayStudentInfo(string connectionString)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Students";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("List of students: ");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Date of Birth: {reader["DateOfBirth"]}, Email: {reader["Email"]}, Phone Number: {reader["PhoneNumber"]}");
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

    public static void GetEnrolledCourses(int studentId, string connectionString)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Enrollments WHERE StudentId = @StudentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Enrolled courses for student with ID {studentId}: ");
                while (reader.Read())
                {
                    Console.WriteLine($"Course ID: {reader["CourseID"]}, Enrollment ID: {reader["EnrollmentID"]}, Enrollment Date: {reader["EnrollmentDate"]}");
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

    public static void GetPaymentHistory(int studentId, string connectionString)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Payments WHERE StudentId = @StudentId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Payment history for student with ID {studentId}: ");
                while (reader.Read())
                {
                    Console.WriteLine($"Payment ID: {reader["PaymentId"]}, Amount: {reader["Amount"]}, Payment Date: {reader["PaymentDate"]}");
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
    }   
}
