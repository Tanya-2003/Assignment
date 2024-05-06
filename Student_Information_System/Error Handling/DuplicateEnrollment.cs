using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;
using Student_Information_System.Details;

namespace Student_Information_System.Error_Handling
{
    internal class DuplicateEnrollment : Exception
    {
        public DuplicateEnrollment(string message) : base(message)
        {

        }

        public static void DuplicateEnrollmentE(int student_id)
        {
            foreach (Enrollment item in EnrollmentDetails.enrollments)
            {
                if (item.StudentID == student_id)
                    throw new DuplicateEnrollment("Student already enrolled. Try again!!!");
            }
        }
    }
}
