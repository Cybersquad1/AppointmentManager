using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.Models;

namespace AppointmentManager
{
    interface IAppointmentDetailsProvider
    {
        AppointmentDetail GetAppointmentDetails(Guid appointmentId);
    }
}
