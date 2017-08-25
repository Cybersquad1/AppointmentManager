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
    public class DeleteAppointmentTests
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
        public void DeleteNonExistingAppointment()
        {
            var appointment = new Appointment
            {
                AppointmentName = "test",
                AppointmentTime = DateTime.Now
            };

            var deleteResponse = _repository.DeleteAppointment(appointment);
            Assert.IsFalse(deleteResponse);
            
        }

        [TestMethod]
        public void DeleteExistingAppointment()
        {
            var appointment = new Appointment
            {
                AppointmentName = "test",
                AppointmentTime = DateTime.Now
            };

            var appointmentDetail = new AppointmentDetail
            {
                Appointment = appointment,
                Organiser = "organiser",
                Attendees = new List<string> {"attendee1", "attendee2"}
            };

            _repository.AddAppointment(appointmentDetail);

            var deleteResponse = _repository.DeleteAppointment(appointment);
            Assert.IsTrue(deleteResponse);
            Assert.IsTrue(!_repository.GetAllAppointments().Any());

        }



    }


}
