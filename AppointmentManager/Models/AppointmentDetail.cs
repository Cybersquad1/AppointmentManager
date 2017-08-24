using System;
using System.Collections.Generic;

namespace AppointmentManager.Models
{
    public class AppointmentDetail
    {
        public AppointmentDetail()
        {
            Attendees = new List<string>();
        }
        public Guid AppointmentId { get; set; }
        public string Organiser { get; set; }
        public List<string> Attendees { get; set; }
    }
}