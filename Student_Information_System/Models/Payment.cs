using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(int paymentID, int studentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            StudentID = studentID;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        //constructor overload
        public Payment(decimal amount, DateTime paymentDate)
        {
            Amount = amount;
            PaymentDate = paymentDate;
        }
        public Payment() { }

        public override string ToString()
        {
            return $"{PaymentID} {StudentID} {Amount} {PaymentDate}";
        }
        /*
        public Student GetStudent(List<Student> students)
        {
            return students.FirstOrDefault(s => s.StudentID == StudentID);
        }

        public decimal GetPaymentAmount()
        {
            return Amount;
        }

        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }*/
    }
}
