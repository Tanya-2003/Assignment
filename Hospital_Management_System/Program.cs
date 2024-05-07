using Hospital_Management_System.Dao;
using Hospital_Management_System.Models;
using Hospital_Management_System.util;
using Hospital_Management_System.ExceptionHandling;

using System;

namespace Hospital_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            HospitalServiceImpl hospitalService = new HospitalServiceImpl(new HmsContext());

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Get Appointment by ID");
            Console.WriteLine("2. Get Appointments for Patient");
            Console.WriteLine("3. Get Appointments for Doctor");
            Console.WriteLine("4. Schedule Appointment");
            Console.WriteLine("5. Update Appointment");
            Console.WriteLine("6. Cancel Appointment");
            Console.WriteLine("7. Exit");

            while (true)
            {
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice > 7)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Appointment ID: ");
                        int appointmentId = int.Parse(Console.ReadLine());
                        Appointment appointment = hospitalService.GetAppointmentById(appointmentId);
                        if (appointment != null)
                        {
                            Console.WriteLine($"Appointment with ID {appointmentId} found:");
                            Console.WriteLine($"Patient ID: {appointment.PatientId}");
                            Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                            Console.WriteLine($"Date: {appointment.AppointmentDate}");
                            Console.WriteLine($"Description: {appointment.Description}");
                        }
                        else
                        {
                            Console.WriteLine($"Appointment with ID {appointmentId} not found");
                        }
                        break;

                    case 2:
                        Console.Write("Enter Patient ID: ");
                        int patientId = int.Parse(Console.ReadLine());
                        try
                        {
                            var appointmentsForPatient = hospitalService.GetAppointmentsForPatient(patientId);
                            if (appointmentsForPatient.Count > 0)
                            {
                                Console.WriteLine($"Appointments for Patient ID {patientId}:");
                                foreach (var apt in appointmentsForPatient)
                                {
                                    Console.WriteLine($"Appointment ID: {apt.AppointmentId}, Date: {apt.AppointmentDate}, Doctor ID: {apt.DoctorId}, Description: {apt.Description}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No appointments found for Patient ID {patientId}");
                            }
                        }
                        catch (PatientNumberNotFoundE ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case 3:
                        Console.Write("Enter Doctor ID: ");
                        int doctorId = int.Parse(Console.ReadLine());
                        var appointmentsForDoctor = hospitalService.GetAppointmentsForDoctor(doctorId);
                        if (appointmentsForDoctor.Count > 0)
                        {
                            Console.WriteLine($"Appointments for Doctor ID {doctorId}:");
                            foreach (var apt in appointmentsForDoctor)
                            {
                                Console.WriteLine($"Appointment ID: {apt.AppointmentId}, Date: {apt.AppointmentDate}, Patient ID: {apt.PatientId}, Description: {apt.Description}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No appointments found for Doctor ID {doctorId}");
                        }
                        break;

                    case 4:
                        // Schedule Appointment
                        Console.WriteLine("Enter patient ID:");
                        int newPatientId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter doctor ID:");
                        int newDoctorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter description:");
                        string newDescription = Console.ReadLine();
                        Console.WriteLine("Enter appointment date (yyyy-MM-dd):");
                        DateTime appointmentDate;
                        if (DateTime.TryParse(Console.ReadLine(), out appointmentDate))
                        {
                            Appointment newAppointment = new Appointment()
                            {
                                PatientId = newPatientId,
                                DoctorId = newDoctorId,
                                AppointmentDate = appointmentDate,
                                Description = newDescription
                            };

                            if (hospitalService.ScheduleAppointment(newAppointment))
                            {
                                Console.WriteLine("Appointment scheduled successfully");
                            }
                            else
                            {
                                Console.WriteLine("Failed to schedule appointment");
                            }
                        }
                        break; 

                    case 5:
                                // Update Appointment
                                Console.WriteLine("Enter appointment ID to update:");
                                int updateAppointmentId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new patient ID:");
                                int updatedPatientId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new doctor ID:");
                                int updatedDoctorId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new appointment date (yyyy-MM-dd):");
                                DateTime updatedAppointmentDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter new description:");
                                string updatedDescription = Console.ReadLine();
                                Appointment updatedAppointment = new Appointment()
                                {
                                    AppointmentId = updateAppointmentId,
                                    PatientId = updatedPatientId,
                                    DoctorId = updatedDoctorId,
                                    AppointmentDate = updatedAppointmentDate,
                                    Description = updatedDescription
                                };
                                if (hospitalService.UpdateAppointment(updatedAppointment))
                                {
                                    Console.WriteLine("Appointment updated successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to update appointment");
                                }
                                break;

                            case 6:
                                // Cancel Appointment
                                Console.WriteLine("Enter appointment ID to cancel:");
                                int cancelAppointmentId = int.Parse(Console.ReadLine());
                                if (hospitalService.CancelAppointment(cancelAppointmentId))
                                {
                                    Console.WriteLine($"Appointment with ID {cancelAppointmentId} canceled successfully");
                                }
                                else
                                {
                                    Console.WriteLine($"Failed to cancel appointment with ID {cancelAppointmentId}");
                                }
                                break;

                            case 7:
                                Console.WriteLine("Exiting program...");
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                            }
                        }
                }
            }
        }
