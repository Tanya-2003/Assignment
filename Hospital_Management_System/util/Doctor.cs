using System;
using System.Collections.Generic;

namespace Hospital_Management_System.util;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Specialisation { get; set; }

    public int? Contactnumber { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
