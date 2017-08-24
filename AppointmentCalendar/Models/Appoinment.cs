using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentCalendar.Models
{
    public class Appoinment
    {
        public string AppointmentName { get; set; }
        public DateTime AppointmentTime { get; set; }
        public Lazy<AppointmentDetail> Detail { get; set; }
    }

    public class AppointmentDetail
    {
        public string Organiser { get; set; }
        public List<string> Attendees { get; set; }
    }
}