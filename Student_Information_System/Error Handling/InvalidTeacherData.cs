using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;

namespace Student_Information_System.Error_Handling
{
    internal class InvalidTeacherData : Exception
    {
        public InvalidTeacherData(string message) : base(message)
        {

        }
        public static void InvalidTeacherDataE(Teacher teacher)
        {
            if (teacher.FirstName == null || teacher.LastName == null)
            {
                throw new InvalidTeacherData("Teacher name is null!!!");
            }
            else if (teacher.Email == null)
            {
                throw new InvalidTeacherData("Email is null!!!");
            }
        }
    }
}
