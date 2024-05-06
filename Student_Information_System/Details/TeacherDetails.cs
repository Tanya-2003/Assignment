using System;
using System.ComponentModel.DataAnnotations;
using Student_Information_System.Models;

namespace Student_Information_System.Details
{
	internal class TeacherDetails
	{
		public static List<Teacher> teachers = new List<Teacher>();

		public void InsertDetails(Teacher teacher)
		{
			teachers.Add(teacher);
		}
		public void displayDetails()
		{
			foreach (Teacher item in teachers)
			{
				Console.WriteLine(item);
			}
		}

		public void UpdateTeacherInfo(Teacher teacher)
		{
			foreach (Teacher item in teachers)
			{
				if (item.TeacherID == teacher.TeacherID)
				{
					item.FirstName = teacher.FirstName;
					item.LastName = teacher.LastName;
					item.Email = teacher.Email;
					break;
				}
			}
		}

		public void GetAssignedCourses(string t_name)
		{

			foreach (Course item in CourseDetails.courses)
			{
				if (item.InstructorName == t_name)
				{
					Console.WriteLine(item.CourseName);
				}
			}
		}

	}
}
