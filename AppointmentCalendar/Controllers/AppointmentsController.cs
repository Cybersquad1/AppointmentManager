using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppointmentCalendar.Models;
using AppointmentManager;

namespace AppointmentCalendar.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentProviderContext _appointmentProviderStrategy;

        public AppointmentsController(IAppointmentProviderContext appointmentProviderStrategy)
        {
            _appointmentProviderStrategy = appointmentProviderStrategy;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Calendar()
        {
            CalendarMonths months = new CalendarMonths();
            return View(months);
        }

        
        public PartialViewResult GetAppointmentsForMonth(int month)
        {
            var provider = _appointmentProviderStrategy.GetAppointmentProvider(AppointmentSelector.Monthly);
            var response = provider.GetAppointments(month).ToList();
            List<Appoinment> appointments = new List<Appoinment>();
            foreach (var appointment in response)
            {
                appointments.Add(new Appoinment
                {
                    AppointmentName = appointment.AppointmentName,
                    AppointmentTime = appointment.AppointmentTime
                });
            }
                
            return PartialView("Appointments", appointments);
        }
    }
}