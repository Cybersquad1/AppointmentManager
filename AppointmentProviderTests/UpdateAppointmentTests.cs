using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager;
using AppointmentManager.Data;
using AppointmentManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace AppointmentProviderTests
{
    [TestClass]
    public class UpdateAppointmentTests
    {
        private static IAppointmentDataContext _testContext;
        private static IAppointmentRepositoryContext _appointmentProviderStrategy;
        private static IAppointmentRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _testContext = MockRepository.GenerateStub<IAppointmentDataContext>();
            _testContext.Appointments = new List<Appointment>();
            _testContext.AppointmentDetails = new List<AppointmentDetail>();
            _appointmentProviderStrategy = new AppointmentRepositoryContext(_testContext);
            _repository = _appointmentProviderStrategy.GetAppointmentRepository();
        }

        [TestMethod]
        public void UpdateNonExistentAppointment()
        {
           var updateResponse = _repository.UpdateApointment(new Appointment());
            Assert.IsFalse(updateResponse);

        }

        [TestMethod]
        public void UpdateExistentAppointment()
        {
            var appointment = new Appointment
            {
                AppointmentName = "appointment",
                AppointmentTime = DateTime.Now
            };

            var appointmentDetail = new AppointmentDetail
            {
                Appointment = appointment,
                Organiser = "testOrganiser",
                Attendees = new List<string> {"attendee1", "attendee2"}
            };

            _repository.AddAppointment(appointmentDetail);

            appointment.AppointmentName = "updatedAppointment";

            var updateResponse = _repository.UpdateApointment(appointment);
            var updatedAppointment = _repository.GetAppointmentById(appointment.Id);
            Assert.IsTrue(updatedAppointment.AppointmentName == "updatedAppointment");

        }

    }
}
