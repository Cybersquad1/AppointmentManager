using AppointmentManager.Data;
using AppointmentManager.Models;
using Microsoft.Practices.Unity;

namespace AppointmentManager
{
    public class AppointmentProviderContext : IAppointmentProviderContext
    {
        private IAppointmentDataContext Context { get; set; }

        [InjectionConstructor]
        public  AppointmentProviderContext(IAppointmentDataContext context)
        {
            Context = context;
        }

        public IAppointmentProvider GetAppointmentProvider(AppointmentSelector selector = default(AppointmentSelector))
        {
            switch (selector)
            {
                case AppointmentSelector.Monthly:
                {
                    return new MonthlyAppointmentProvider(Context);
                }
                default:
                {
                    return new AppointmentProvider(Context);
                }
            }
        }
    }
}
