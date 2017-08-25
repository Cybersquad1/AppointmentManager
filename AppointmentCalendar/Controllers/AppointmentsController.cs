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
        private readonly IAppointmentRepositoryContext _appointmentProviderStrategy;
        private readonly IAppointmentRepository _provider;

        public AppointmentsController(IAppointmentRepositoryContext appointmentProviderStrategy)
        {
            _appointmentProviderStrategy = appointmentProviderStrategy;
            _provider = _appointmentProviderStrategy.GetAppointmentRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to a Simple appointment Calendar.";

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public PartialViewResult GetAppointmentsForMonth(int month)
        {
            var monthlyProvider = _appointmentProviderStrategy.GetAppointmentRepository(AppointmentSelector.Monthly);
            var response = monthlyProvider.GetAppointments(month).ToList();
            var appointments = response.Select(
                appointment => new Appoinment
                {
                    Id = appointment.Id, AppointmentName = appointment.AppointmentName, AppointmentTime = appointment.AppointmentTime
                }).ToList();

            return PartialView("Appointments", appointments);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartialViewResult GetAppointmentDetail(Guid id)
        {
            var appointment = _provider.GetAppointmentDetails(id);
            var detail = new AppointmentDetail
            {
                Organiser = appointment.Organiser,
                Attendees = appointment.Attendees
            };
            return PartialView("Details",detail);

        }
    }
}