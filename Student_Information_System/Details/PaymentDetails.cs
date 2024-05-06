using System;
using Student_Information_System.Models;

namespace Student_Information_System.Details
{
    internal class PaymentDetails
    {
        public static List<Payment> payments = new List<Payment>();

        public void InsertDetails(Payment payment)
        {
            payments.Add(payment);
        }

        public void GetStudent(int StudentId)
        {

            foreach (Student item in StudentDetails.stud)
            {
                if (item.StudentID == StudentId)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetPaymentAmount(int PaymentId)
        {
            foreach (Payment item in payments)
            {
                if (item.PaymentID == PaymentId)
                {
                    Console.WriteLine(item.Amount);
                }
            }
        }

        public void GetPaymentdate(int PaymentId)
        {
            foreach (Payment item in payments)
            {
                if (item.PaymentID == PaymentId)
                {
                    Console.WriteLine(item.PaymentDate);
                }
            }
        }

        public void displayDetails()
        {
            foreach (Payment item in payments)
            {
                Console.WriteLine(item);
            }
        }

    }
}
