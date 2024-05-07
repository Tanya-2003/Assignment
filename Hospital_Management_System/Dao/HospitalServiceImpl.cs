using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.Models;
using Hospital_Management_System.util;
using Hospital_Management_System.ExceptionHandling;
using Hospital_Management_System.Dao;

namespace Hospital_Management_System.Dao
{
    internal class HospitalServiceImpl : IHospitalService
    {
        private HmsContext hmsContext;

        public HospitalServiceImpl(HmsContext hmContext)
        {
            this.hmsContext = hmContext;
        }
        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = hmsContext.Appointments.Find(appointmentId);
            return appointment;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                foreach (var appointment in hmsContext.Appointments)
                {
                    if (appointment.PatientId == patientId)
                        appointments.Add(appointment);
                }

                if (appointments.Count == 0)
                    throw new PatientNumberNotFoundE("Patient number not found");

            }
            catch (PatientNumberNotFoundE ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return appointments;
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointmentsForDoctor = new List<Appointment>();

            foreach (var appointment in hmsContext.Appointments)
            {
                if (appointment.DoctorId == doctorId)
                    appointmentsForDoctor.Add(appointment);
            }

            return appointmentsForDoctor;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            try
            {
                hmsContext.Appointments.Add(appointment);
                hmsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scheduling appointment:{ex.InnerException?.Message ?? ex.Message} ");
                return false;
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            try
            {
                var existingAppointment = hmsContext.Appointments.FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId);
                if (existingAppointment != null)
                {
                    existingAppointment.PatientId = appointment.PatientId;
                    existingAppointment.DoctorId = appointment.DoctorId;
                    existingAppointment.AppointmentDate = appointment.AppointmentDate;
                    existingAppointment.Description = appointment.Description;
                   
                    hmsContext.Entry(existingAppointment).State = EntityState.Modified;
                    hmsContext.SaveChanges();

                    hmsContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                return false;
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            try
            {
                var appointment = hmsContext.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    hmsContext.Appointments.Remove(appointment);
                    hmsContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error canceling appointment: {ex.Message}");
                return false;
            }
        }


    }
}