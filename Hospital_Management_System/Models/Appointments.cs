using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Appointments
    {

        // Private fields
        private int appointmentId;
        private int patientId;
        private int doctorId;
        private DateTime appointmentDate;
        private string description;

        // Properties
        public int AppointmentId
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        // Default Constructor
        public Appointments() { }

       // Parameterized Constructor
       public Appointments(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
       {
            this.appointmentId = appointmentId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.appointmentDate = appointmentDate;
            this.description = description;
       }

       // ToString method
       public override string ToString()
       {
           return $"Appointment ID: {appointmentId}, Patient ID: {patientId}, Doctor ID: {doctorId}, Appointment Date: {appointmentDate}, Description: {description}";
       }
    }
}
