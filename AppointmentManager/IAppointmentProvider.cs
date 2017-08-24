using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.Data;
using AppointmentManager.Models;

namespace AppointmentManager
{
    public interface IAppointmentProvider
    {
        IEnumerable<Appointment> GetAllAppointments();
        IEnumerable<Appointment> GetAppointments(int selector);
        Type GetProviderType();
    }
}
