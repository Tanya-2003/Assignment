using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;
using Student_Information_System.Details;

namespace Student_Information_System.Error_Handling
{
    internal class StudentNotFound : Exception
    {
        public StudentNotFound(string message) : base(message)
        {

        }

        public static void StudentNotFoundE(int studentId)
        {
            bool studentExists = false;
            foreach (Student item in StudentDetails.stud)
            {
                if (item.StudentID == studentId)
                {
                    studentExists = true;
                    break;
                }
            }
            if (!studentExists)
            {
                throw new StudentNotFound("Student not found!!!");
            }
        }
    }
}
