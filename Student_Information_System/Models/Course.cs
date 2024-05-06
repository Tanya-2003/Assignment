using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }
        //
        public List<string> Enrollments { get; private set; }
        public Teacher AssignedTeacher { get; private set; }

        public Course() { }
        public Course(int courseID, string courseName, string courseCode, string instructorName)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
            //
            Enrollments = new List<string>();
            AssignedTeacher = null;
        }

        public void AssignTeacher(Teacher teacher)
        {
            //InstructorName = $"{teacher.FirstName} {teacher.LastName}";
            AssignedTeacher = teacher;
        }

        //
        public void UpdateCourseInfo(string courseCode, string courseName, string instructorName)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            InstructorName = instructorName;
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine("Course Id: " + CourseID);
            Console.WriteLine("Course Name: " + CourseName);
            Console.WriteLine("Course Code: " + CourseCode);
            Console.WriteLine("Instructor Name: " + InstructorName);
            if (AssignedTeacher != null)
            {
                Console.WriteLine("Assigned Teacher: " + AssignedTeacher.FirstName);
            }
            else
            {
                Console.WriteLine("Teacher: Not assigned");
            }
            Console.WriteLine("Number of Enrollments: " + Enrollments.Count);
        }

        public List<string> GetEnrollments()
        {
            return Enrollments;
        }

        public Teacher GetTeacher()
        {
            return AssignedTeacher;
        }

        public override string ToString()
        {
            return $"{CourseID} {CourseName} {CourseCode} {InstructorName}";
        }

    }
}
