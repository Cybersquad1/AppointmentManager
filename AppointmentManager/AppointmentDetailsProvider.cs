using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.Data;
using AppointmentManager.Models;

namespace AppointmentManager
{
    public class AppointmentDetailsProvider : IAppointmentDetailsProvider
    {
        private IAppointmentDataContext Context { get; }

        public AppointmentDetailsProvider(IAppointmentDataContext context)
        {
            Context = context;
        }

        public AppointmentDetail GetAppointmentDetails(Guid appointmentId)
        {
            return Context.AppointmentDetails.SingleOrDefault(p => p.AppointmentId == appointmentId);
        }
    }
}
