using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;

namespace Student_Information_System.Details
{
    internal class StudentDetails
    {
        public static List<Student> stud = new List<Student>();

        public void InsertRecords(Student students)
        {
            stud.Add(students);
        }

        public void EnrollInCourse(Course course, int id, int e_id, DateTime e_date)
        {
            EnrollmentDetails.enrollments.Add(new Enrollment(e_id, id, course.CourseID, e_date));
        }

        public void UpdateStudentInfo(Student students)
        {
            foreach (Student stud in stud)
            {
                if (stud.StudentID == students.StudentID)
                {
                    stud.FirstName = students.FirstName;
                    stud.LastName = students.LastName;
                    stud.DateOfBirth = students.DateOfBirth;
                    stud.Email = students.Email;
                    stud.PhoneNumber = students.PhoneNumber;
                    break;
                }
            }
        }

        public void MakePayment(int p_id, int id, decimal amount, DateTime payment_date)
        {

            PaymentDetails.payments.Add(new Payment(p_id, id, amount, payment_date));
        }

        public void GetEnrolledCourses(int s_id)
        {

            foreach (Enrollment item in EnrollmentDetails.enrollments)
            {
                if (item.StudentID == s_id)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetPaymentHistory(int s_id)
        {
            foreach (Payment item in PaymentDetails.payments)
            {
                if (item.StudentID == s_id)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void DisplayStudentInfo()
        {
            foreach (Student item in stud)
            {
                Console.WriteLine(item);
            }
        }
    }
}