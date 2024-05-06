using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;

namespace Student_Information_System.Error_Handling
{
    internal class InvalidStudentData : Exception
    {
        public InvalidStudentData(string message) : base(message)
        {

        }
        public static void InvalidStudentDataE(Student student)
        {
            if (student.DateOfBirth > DateTime.Now)
            {
                throw new InvalidStudentData("Invalid date of birth!!!");
            }
            else if (!student.Email.Contains('@'))
            {
                throw new InvalidStudentData("Invalid email address!!!");
            }
        }
    }
}
