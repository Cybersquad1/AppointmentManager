using System;
using System.Collections.Generic;
using AppointmentManager.Models;

namespace AppointmentManager.Data
{
    public class AppointmentDataContext :IAppointmentDataContext
    {
        public List<Appointment> Appointments { get; set; }

        public List<AppointmentDetail> AppointmentDetails { get; set; }

        public AppointmentDataContext()
        {
            Appointments = new List<Appointment>();
            AppointmentDetails = new List<AppointmentDetail>();

            var appointment1 = new Appointment
            {
                AppointmentName = "Team Meeting",
                AppointmentTime = new DateTime(2014, 02, 08),
            };

            var appointmentDetail1 = new AppointmentDetail
            {
                AppointmentId = appointment1.Id,
                Organiser = "Max Mustermann",
                Attendees = new List<string> {"John Smith" , "Robert Turner", "Erika Gobler"}
            };

            Appointments.Add(appointment1);
            AppointmentDetails.Add(appointmentDetail1);


            var appointment2 = new Appointment
            {
                AppointmentName = "Lunch With Joe",
                AppointmentTime = new DateTime(2014, 02, 16),
            };

            var appointmentDetail2 = new AppointmentDetail
            {
                AppointmentId = appointment2.Id,
                Organiser = "Tim Lee",
                Attendees = new List<string> { "Blaise Pascal", "Enrico Fermi", "Jane Goodall" }
            };

            Appointments.Add(appointment2);
            AppointmentDetails.Add(appointmentDetail2);

            var appointment3 = new Appointment
            {
                AppointmentName = "Project Meeting",
                AppointmentTime = new DateTime(2014, 02, 19),
            };

            var appointmentDetail3 = new AppointmentDetail
            {
                AppointmentId = appointment3.Id,
                Organiser = "Max Planck",
                Attendees = new List<string> { "Sarah Boysen", "Stephen Hawking", "Niels Bohr" }
            };

            Appointments.Add(appointment3);
            AppointmentDetails.Add(appointmentDetail3);


        }
        
    }
}
