using System;
using System.Collections.Generic;

namespace AppointmentManager.Models
{
    public class Appointment
    {
        public Appointment()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string AppointmentName { get; set; }
        public DateTime AppointmentTime { get; set; }

    }
}