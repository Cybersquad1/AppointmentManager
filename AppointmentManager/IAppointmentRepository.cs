using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.Data;
using AppointmentManager.Models;

namespace AppointmentManager
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        IEnumerable<Appointment> GetAppointments(int selector);
        Appointment GetAppointmentById(Guid id);
        AppointmentDetail GetAppointmentDetails(Guid appointmentId);
        void AddAppointment(AppointmentDetail appointment);
        bool DeleteAppointment(Appointment appointment);
        bool UpdateApointment(Appointment updatedAppointment);
        Type GetProviderType();
    }
}
