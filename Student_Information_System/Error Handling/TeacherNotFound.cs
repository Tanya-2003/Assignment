using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;
using Student_Information_System.Details;

namespace Student_Information_System.Error_Handling
{
    internal class TeacherNotFound : Exception
    {
        public TeacherNotFound(string message) : base(message)
        {

        }

        public static void TeacherNotFoundE(Teacher teacher)
        {
            if (!TeacherDetails.teachers.Contains(teacher))
            {
                throw new TeacherNotFound("Teacher not found!!");
            }
        }
    }
}
