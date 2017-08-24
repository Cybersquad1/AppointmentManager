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
    public class GetAppointmentProviderContextTests
    {
        private IAppointmentProviderContext ProviderContext { get; set; }
        private IAppointmentDataContext _testContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _testContext = MockRepository.GenerateStub<IAppointmentDataContext>();
            ProviderContext = new AppointmentProviderContext(_testContext);
        }


        [TestMethod]
        public void ResolutionOfDefaultProvider()
        {
            var provider = ProviderContext.GetAppointmentProvider();
            Assert.IsTrue(provider.GetProviderType() == typeof(AppointmentProvider));
        }

        [TestMethod]
        public void ResolutionOfMonthlyProvider()
        {
            var provider = ProviderContext.GetAppointmentProvider(AppointmentSelector.Monthly);
            Assert.IsTrue(provider.GetProviderType() == typeof(MonthlyAppointmentProvider));
        }
    }
}
