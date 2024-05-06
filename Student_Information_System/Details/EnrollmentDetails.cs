using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;
using Student_Information_System.Details;

namespace Student_Information_System.Details
{
    internal class EnrollmentDetails
    {
        public static List<Enrollment> enrollments = new List<Enrollment>();
        public void InsertDetails(Enrollment enrollment)
        {
            enrollments.Add(enrollment);
        }

        public void DisplayDetails()
        {
            foreach (Enrollment item in enrollments)
            {
                Console.WriteLine(item);
            }
        }

        public void GetStudent(int studentId)
        {

            foreach (Student item in StudentDetails.stud)
            {
                if (item.StudentID == studentId)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetCourse(int courseId)
        {

            foreach (Course item in CourseDetails.courses)
            {
                if (item.CourseID == courseId)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
