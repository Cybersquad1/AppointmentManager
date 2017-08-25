using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager;
using AppointmentManager.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace AppointmentProviderTests
{
    [TestClass]
    public class GetAppointmentRepostiryContextTests
    {
        private IAppointmentRepositoryContext ProviderContext { get; set; }
        private IAppointmentDataContext _testContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _testContext = MockRepository.GenerateStub<IAppointmentDataContext>();
            ProviderContext = new AppointmentRepositoryContext(_testContext);
        }


        [TestMethod]
        public void ResolutionOfDefaultProvider()
        {
            var provider = ProviderContext.GetAppointmentRepository();
            Assert.IsTrue(provider.GetProviderType() == typeof(AppointmentRepository));
        }

        [TestMethod]
        public void ResolutionOfMonthlyProvider()
        {
            var provider = ProviderContext.GetAppointmentRepository(AppointmentSelector.Monthly);
            Assert.IsTrue(provider.GetProviderType() == typeof(MonthlyAppointmentRepository));
        }
    }
}
