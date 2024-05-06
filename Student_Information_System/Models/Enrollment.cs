using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //
        public Enrollment() { }

        public Enrollment(int enrollmentID, int studentID, int courseID, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentID;
            StudentID = studentID;
            CourseID = courseID;
            EnrollmentDate = enrollmentDate;
        }

        public override string ToString()
        {
            return $"{EnrollmentID} {StudentID} {CourseID} {EnrollmentDate}";
        }
        /*
        public Student GetStudent(List<Student> students)
        {
            
            return students.FirstOrDefault(s => s.StudentID == StudentID);
        }

        public Course GetCourse(List<Course> courses)
        {
            return courses.FirstOrDefault(c => c.CourseID == CourseID);
        }*/
    }
}
