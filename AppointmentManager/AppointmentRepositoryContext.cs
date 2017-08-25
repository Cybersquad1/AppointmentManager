using AppointmentManager.Data;
using AppointmentManager.Models;
using Microsoft.Practices.Unity;

namespace AppointmentManager
{
    public class AppointmentRepositoryContext : IAppointmentRepositoryContext
    {
        private IAppointmentDataContext Context { get; set; }

        [InjectionConstructor]
        public  AppointmentRepositoryContext(IAppointmentDataContext context)
        {
            Context = context;
        }

        public IAppointmentRepository GetAppointmentRepository(AppointmentSelector selector = default(AppointmentSelector))
        {
            switch (selector)
            {
                case AppointmentSelector.Monthly:
                {
                    return new MonthlyAppointmentRepository(Context);
                }
                default:
                {
                    return new AppointmentRepository(Context);
                }
            }
        }
    }
}
