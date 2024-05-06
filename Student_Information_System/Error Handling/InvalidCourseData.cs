using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;

namespace Student_Information_System.Error_Handling
{
    internal class InvalidCourseData : Exception
    {
        public InvalidCourseData(string message) : base(message)
        {

        }

        public static void InvalidCourseDataE(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseCode))
            {
                throw new InvalidCourseData("Invalid course code!!");
            }
            else if (string.IsNullOrWhiteSpace(course.InstructorName))
            {
                throw new InvalidCourseData("Invalid instructor name!!");
            }
        }
    }
}
