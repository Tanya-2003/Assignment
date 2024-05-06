using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       
        public Teacher(int teacherID, string firstName, string lastName, string email)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            //Expertise = expertise;
            //AssignedCourses = new List<Course>();
        }

        public void UpdateTeacherInfo(string name, string email)
        {
            FirstName = name;
            Email = email;
        }

        public Teacher() { }


        //public void DisplayTeacherInfo()
        //{
        //    Console.WriteLine("Teacher ID: " + TeacherID);
        //    Console.WriteLine("Name: " + FirstName + " " + LastName);
        //    Console.WriteLine("Email: " + Email);
        //    Console.WriteLine("Expertise: " + Expertise);
        //    Console.WriteLine("Number of Assigned Courses: " + AssignedCourses.Count);
        //}

        //public List<Course> GetAssignedCourses()
        //{
        //    return AssignedCourses;
        //}
    }
}
