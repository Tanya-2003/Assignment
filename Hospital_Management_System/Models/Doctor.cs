using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        private int doctorId;
        private string firstName;
        private string lastName;
        private string specialization;
        private string contactNumber;

        // Properties
        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        // Default Constructor
        public Doctor() { }

        // Parameterized Constructor
        public Doctor(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
            ContactNumber = contactNumber;
            }

        // ToString method
        public override string ToString()
        {
           return $"Doctor ID: {DoctorId}, Name: {FirstName} {LastName}, Specialization: {Specialization}, Contact Number: {ContactNumber}";
        }
        }
    }

