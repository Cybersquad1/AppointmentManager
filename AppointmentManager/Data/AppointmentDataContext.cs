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
                AppointmentTime = new DateTime(2014, 02, 08 ,11,3,5),
            };

            var appointmentDetail1 = new AppointmentDetail
            {
                Appointment = appointment1,
                Organiser = "Max Mustermann",
                Attendees = new List<string> {"John Smith" , "Robert Turner", "Erika Gobler"}
            };

            Appointments.Add(appointment1);
            AppointmentDetails.Add(appointmentDetail1);


            var appointment2 = new Appointment
            {
                AppointmentName = "Lunch With Joe",
                AppointmentTime = new DateTime(2014, 02, 16,13,7,8),
            };

            var appointmentDetail2 = new AppointmentDetail
            {
                Appointment = appointment2,
                Organiser = "Tim Lee",
                Attendees = new List<string> { "Blaise Pascal", "Enrico Fermi", "Jane Goodall" }
            };

            Appointments.Add(appointment2);
            AppointmentDetails.Add(appointmentDetail2);

            var appointment3 = new Appointment
            {
                AppointmentName = "Project Meeting",
                AppointmentTime = new DateTime(2014, 02, 19,5,6,5),
            };

            var appointmentDetail3 = new AppointmentDetail
            {
                Appointment = appointment3,
                Organiser = "Max Planck",
                Attendees = new List<string> { "Sarah Boysen", "Stephen Hawking", "Niels Bohr" }
            };

            Appointments.Add(appointment3);
            AppointmentDetails.Add(appointmentDetail3);


            var appointment4 = new Appointment
            {
                AppointmentName = "Scrum Meeting",
                AppointmentTime = new DateTime(2014, 05, 19,1,2,3),
            };

            var appointmentDetail4 = new AppointmentDetail
            {
                Appointment = appointment4,
                Organiser = "Tim Cook",
                Attendees = new List<string> { "Jane Goodall", "Stephen Hawking", "Lord Kelvin" }
            };

            Appointments.Add(appointment4);
            AppointmentDetails.Add(appointmentDetail4);


            var appointment5 = new Appointment
            {
                AppointmentName = "Scrum Meeting",
                AppointmentTime = new DateTime(2014, 08, 19,11,34,56),
            };

            var appointmentDetail5 = new AppointmentDetail
            {
                Appointment = appointment5,
                Organiser = "Jim Cook",
                Attendees = new List<string> { "Jane Goodall", "Stephen Hawking", "Lord Kelvin" }
            };

            Appointments.Add(appointment5);
            AppointmentDetails.Add(appointmentDetail5);

            var appointment6 = new Appointment
            {
                AppointmentName = "Retrospective Meeting",
                AppointmentTime = new DateTime(2014, 08, 19,17,56,34),
            };

            var appointmentDetail6 = new AppointmentDetail
            {
                Appointment = appointment6,
                Organiser = "Tim Lee",
                Attendees = new List<string> { "Jane Goodall", "Stephen Hawking", "Lord Kelvin" }
            };

            Appointments.Add(appointment6);
            AppointmentDetails.Add(appointmentDetail6);


        }
        
    }
}
