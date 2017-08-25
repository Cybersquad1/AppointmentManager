using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppointmentManager;
using AppointmentManager.Models;
using Rhino.Mocks;

namespace AppointmentProviderTests
{
    [TestClass]
    public class GetAppointmentDetailsTests
    {
        private static IAppointmentDataContext _testContext;
        private static IAppointmentProviderContext _appointmentProviderStrategy;

        [TestInitialize]
        public void Initialize()
        {
            _testContext = MockRepository.GenerateStub<IAppointmentDataContext>();
            _testContext.Appointments = new List<Appointment>();
            _testContext.AppointmentDetails = new List<AppointmentDetail>();
            _appointmentProviderStrategy = new AppointmentProviderContext(_testContext);
        }

        [TestMethod]
        public void GetAppointmentDetailsForNonExistantAppointmentReturnsNull()
        {
            Guid id = Guid.NewGuid();
            var provider = _appointmentProviderStrategy.GetAppointmentProvider();
            var appointmentDetail = provider.GetAppointmentDetails(id);
            Assert.IsTrue(appointmentDetail==null);
        }


        [TestMethod]
        public void GetAppointmentDetailForExistingAppointment()
        {
            var appointmentWithDetail = new Appointment
            {
                AppointmentTime = DateTime.Now,
                AppointmentName = "AppointmentWithDetail"
            };
            var appointmentDetail = new AppointmentDetail
            {
                AppointmentId = appointmentWithDetail.Id,
                Organiser = "organiser",
                Attendees = new List<string> { "attendee1","attendee2"}
            };

            var provider = _appointmentProviderStrategy.GetAppointmentProvider();
            _testContext.Appointments.Add(appointmentWithDetail);
            _testContext.AppointmentDetails.Add(appointmentDetail);
            var detail = provider.GetAppointmentDetails(appointmentDetail.AppointmentId);
            Assert.AreEqual(detail,appointmentDetail);

        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DuplicateAppointmentDetailForSameAppointmentThrowsException()
        {
            var appointmentWithDetail = new Appointment
            {
                AppointmentTime = DateTime.Now,
                AppointmentName = "AppointmentWithDetail"
            };
            var appointmentDetail = new AppointmentDetail
            {
                AppointmentId = appointmentWithDetail.Id,
                Organiser = "organiser",
                Attendees = new List<string> { "attendee1", "attendee2" }
            };

            var appointmentDetail2 = new AppointmentDetail
            {
                AppointmentId = appointmentWithDetail.Id,
                Organiser = "organiser2",
                Attendees = new List<string> {"attendee3", "attendee4"}
            };

            var provider = _appointmentProviderStrategy.GetAppointmentProvider();
            _testContext.Appointments.Add(appointmentWithDetail);
            _testContext.AppointmentDetails.Add(appointmentDetail);
            _testContext.AppointmentDetails.Add(appointmentDetail2);
            provider.GetAppointmentDetails(appointmentDetail.AppointmentId);

        }


    }
}
