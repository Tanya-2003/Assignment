using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Student_Information_System.Models;

namespace Student_Information_System.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public List<Course> EnrolledCourses { get; private set; }
        //public List<Payment> PaymentHistory { get; private set; }


        public Student(int studentID, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            //EnrolledCourses = new List<Course>();
            //PaymentHistory = new List<Payment>();
        }

        public override string ToString()
        {
            return $"{StudentID} {FirstName} {LastName} {DateOfBirth} {Email} {PhoneNumber}";
        }

        public Student() { }

        /* Methods
        public void EnrollInCourse(Course course)
        {
            EnrolledCourses.Add(course);
        }

        public void UpdateStudentInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            //Payment newPayment = new Payment(this.StudentID, this.StudentID, amount, paymentDate);
            //PaymentHistory.Add(newPayment);
            
            PaymentHistory.Add(new Payment(amount, paymentDate));
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student ID: {StudentID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Date of Birth: {DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
        }

        public List<Course> GetEnrolledCourses()
        {
            return EnrolledCourses;
        }

        public List<Payment> GetPaymentHistory()
        {
            return PaymentHistory;
        }*/
        //
    }
}
