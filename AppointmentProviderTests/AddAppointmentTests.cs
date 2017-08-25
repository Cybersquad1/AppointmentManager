using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
    public class AddAppointmentTests
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
        public void AddAppointmentAndThenGetReturnsSame()
        {
            var appointment = new Appointment
            {
                AppointmentName = "test",
                AppointmentTime = DateTime.Now,
            };

            var appointmentDetail = new AppointmentDetail
            {
                Appointment = appointment,
                Organiser = "testo",
                Attendees = new List<string> {"test1", "test2"}
            };

            
            _repository.AddAppointment(appointmentDetail);

            var savedAppointment = _repository.GetAllAppointments().First();
            Assert.AreEqual(appointment,savedAppointment);
        }


        [TestMethod]
        public void Add2AppointmentsAndThenGetOneInFebruary()
        {
            int month = 2;

            var repository = _appointmentProviderStrategy.GetAppointmentRepository(AppointmentSelector.Monthly);

            var appointment1 = new Appointment
            {
                AppointmentName = "test",
                AppointmentTime = new DateTime(2017,month,1),
            };

            var appointmentDetail1 = new AppointmentDetail
            {
                Appointment = appointment1,
                Organiser = "testo",
                Attendees = new List<string> { "test1", "test2" }
            };
           
            repository.AddAppointment(appointmentDetail1);

            

            var appointment2 = new Appointment
            {
                AppointmentName = "test2",
                AppointmentTime = DateTime.Now,
            };

            var appointmentDetail2 = new AppointmentDetail
            {
                Appointment = appointment2,
                Organiser = "testo",
                Attendees = new List<string> { "test1", "test2" }
            };

            
            repository.AddAppointment(appointmentDetail2);

            var savedAppointment = repository.GetAppointments(month).First();
            Assert.AreEqual(appointment1, savedAppointment);
        }

    }
}
