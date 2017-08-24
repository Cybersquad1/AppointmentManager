using System.Collections.Generic;
using AppointmentManager.Models;

namespace AppointmentManager.Data
{
    public interface IAppointmentDataContext
    {
        List<Appointment> Appointments { get; set; }
        List<AppointmentDetail> AppointmentDetails { get; set; }
        
    }
}