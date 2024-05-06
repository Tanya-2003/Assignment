using System;
using System.Data;
using System.Data.SqlClient;
using Student_Information_System.Models;


namespace Student_Information_System.Database
{
    public class PaymentDB
    {
       public static void InsertPayment(int p_id, int s_id, decimal amount, DateTime p_date, string connectionString)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO Payments (PaymentId, StudentId, Amount, PaymentDate) VALUES (@PaymentId, @StudentId, @Amount, @PaymentDate)";
                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@PaymentId", p_id);
                        command.Parameters.AddWithValue("@StudentId", s_id);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@PaymentDate", p_date);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Payment recorded successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to record payment.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

       public static void GetPaymentsByStudentId(int studentId, string connectionString)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string selectQuery = "SELECT * FROM Payments WHERE StudentId = @StudentId";
                            SqlCommand command = new SqlCommand(selectQuery, connection);
                            command.Parameters.AddWithValue("@StudentId", studentId);

                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.WriteLine($"Payment ID: {reader["PaymentId"]}, Amount: {reader["Amount"]}, Payment Date: {reader["PaymentDate"]}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

       public static void GetPaymentAmountById(int paymentId, string connectionString)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string selectQuery = "SELECT Amount FROM Payments WHERE PaymentId = @PaymentId";
                            SqlCommand command = new SqlCommand(selectQuery, connection);
                            command.Parameters.AddWithValue("@PaymentId", paymentId);

                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                Console.WriteLine($"Payment Amount: {result}");
                            }
                            else
                            {
                                Console.WriteLine("Payment not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
       
       public static void GetPaymentDateById(int paymentId1, string connectionString)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string selectQuery = "SELECT PaymentDate FROM Payments WHERE PaymentId = @PaymentId";
                        SqlCommand command = new SqlCommand(selectQuery, connection);
                        command.Parameters.AddWithValue("@PaymentId", paymentId1);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            Console.WriteLine($"Payment Date: {result}");
                        }
                        else
                        {
                            Console.WriteLine("Payment not found.");
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

                        string selectQuery = "SELECT * FROM Payments";
                        SqlCommand command = new SqlCommand(selectQuery, connection);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"Payment ID: {reader["PaymentId"]}, Student ID: {reader["StudentId"]}, Amount: {reader["Amount"]}, Payment Date: {reader["PaymentDate"]}");
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



