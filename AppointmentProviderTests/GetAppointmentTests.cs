using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentManager;
using AppointmentManager.Data;
using AppointmentManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace AppointmentProviderTests
{
    [TestClass]
    public class GetAppointmentTests
    {
        private static IAppointmentDataContext _testContext;
        private static IAppointmentRepositoryContext _appointmentProviderStrategy;


        [TestInitialize]
        public void Initialize()
        {
            _testContext = MockRepository.GenerateStub<IAppointmentDataContext>();
            _testContext.Appointments = new List<Appointment>();
            _testContext.AppointmentDetails = new List<AppointmentDetail>();
            _appointmentProviderStrategy = new AppointmentRepositoryContext(_testContext);
            
        }


        /* Basic Plumbing Tests */

        [TestMethod]
        public void NoAppointmentReturnsEmpty()
        {
            var provider = _appointmentProviderStrategy.GetAppointmentRepository();
            Assert.IsTrue(!provider.GetAllAppointments().Any());
        }

        [TestMethod]
        public void OneAppointmentCreatedReturnsOne()
        {
            var provider = _appointmentProviderStrategy.GetAppointmentRepository();
            _testContext.Appointments.Add(new Appointment());
            Assert.IsTrue(provider.GetAllAppointments().Count() == 1);
        }


        [TestMethod]
        public void OneAppointmentCreatedAndRemovedReturnsEmpty()
        {
            var provider = _appointmentProviderStrategy.GetAppointmentRepository();
            _testContext.Appointments.Add(new Appointment());
            Assert.IsTrue(provider.GetAllAppointments().Count() == 1);
            _testContext.Appointments.Clear();
            Assert.IsTrue(!provider.GetAllAppointments().Any());
        }

        /*end*/


        /*Filter Tests*/

       


        [TestMethod]
        public void AddAppointmentFilterByMonth()
        {
            var provider = _appointmentProviderStrategy.GetAppointmentRepository(AppointmentSelector.Monthly);
            var appointmentDate1 = DateTime.Now.AddMonths(3);
            var appointmentDate2 = DateTime.Now.AddMonths(2);
            var appointmentName1 = "test1";
            var appointmentName2 = "test2";
            _testContext.Appointments.Add(new Appointment { AppointmentName = appointmentName1, AppointmentTime = appointmentDate1});
            _testContext.Appointments.Add(new Appointment { AppointmentName = appointmentName2, AppointmentTime = appointmentDate2 });
            var appointments = provider.GetAppointments(appointmentDate1.Month).ToList();
            Assert.IsTrue(appointments.Count == 1);
            Assert.IsTrue(appointments.Single().AppointmentName == appointmentName1);
        }

        [TestMethod]
        public void AddAppointmentsFilterByMonth()
        {
            var provider = _appointmentProviderStrategy.GetAppointmentRepository(AppointmentSelector.Monthly);
            var appointmentDate1 = DateTime.Now.AddMonths(3);
            var appointmentDate2 = DateTime.Now.AddMonths(3);
            var appointmentDate3 = DateTime.Now.AddMonths(2);
            var appointmentName1 = "test1";
            var appointmentName2 = "test2";
            var appointmentName3 = "test3";
            _testContext.Appointments.Add(new Appointment { AppointmentName = appointmentName1, AppointmentTime = appointmentDate1 });
            _testContext.Appointments.Add(new Appointment { AppointmentName = appointmentName2, AppointmentTime = appointmentDate2 });
            _testContext.Appointments.Add(new Appointment { AppointmentName = appointmentName3, AppointmentTime = appointmentDate3 });
            var appointments = provider.GetAppointments(appointmentDate1.Month).ToList();
            Assert.IsTrue(appointments.Count == 2);
            
        }



        /*end*/


    }
}
