using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;

namespace Student_Information_System.Error_Handling
{
	internal class InvalidEnrollmentData : Exception
	{
		public InvalidEnrollmentData(string message) : base(message)
		{

		}

		public static void InvalidEnrollmentDataE(Enrollment enrollment)
		{
			if (enrollment.StudentID == null)
			{
				throw new InvalidEnrollmentData("Student id missing");
			}
			else if (enrollment.CourseID == null)
			{
				throw new InvalidEnrollmentData("Course id missing");
			}
		}
	}
}
