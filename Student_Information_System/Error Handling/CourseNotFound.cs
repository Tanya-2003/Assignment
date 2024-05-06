using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;
using Student_Information_System.Details;

namespace Student_Information_System.Error_Handling
{
    internal class CourseNotFound : Exception
    {
        public CourseNotFound(string message) : base(message)
        {

        }

        public static void CourseNotFoundE(Course course)
        {
            if (!CourseDetails.courses.Contains(course))
            {
                throw new CourseNotFound("Course not found!!");
            }
        }
    }
}
