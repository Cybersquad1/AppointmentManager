using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentManager.Data;
using AppointmentManager.Models;

namespace AppointmentManager
{
    public class AppointmentProvider : IAppointmentProvider
    {
        protected IAppointmentDataContext Context { get;}

        public AppointmentProvider(IAppointmentDataContext context)
        {
            Context = context;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return Context.Appointments;
        }

        //default year filtering implementation
        public virtual IEnumerable<Appointment> GetAppointments(int selector)
        {
            return Context.Appointments.Where(p => p.AppointmentTime.Year == selector);
        }

        public virtual AppointmentDetail GetAppointmentDetails(Guid appointmentId)
        {
            return Context.AppointmentDetails.SingleOrDefault(p => p.AppointmentId == appointmentId);
        }

        public virtual Type GetProviderType()
        {
            return GetType();
        }
    }

    /// <summary>
    /// Appointment provider for Month
    /// </summary>
    public class MonthlyAppointmentProvider : AppointmentProvider
    {
        public MonthlyAppointmentProvider(IAppointmentDataContext context) : base(context)
        {
        }

        public override IEnumerable<Appointment> GetAppointments(int month)
        {
            return Context.Appointments.Where(p => p.AppointmentTime.Month == month);
        }
    }


    /// <summary>
    /// AppointmentProvider for Day
    /// </summary>
    public class DailyAppointmentProvider : AppointmentProvider
    {
        public DailyAppointmentProvider(IAppointmentDataContext context) : base(context)
        {

        }

        public override IEnumerable<Appointment> GetAppointments(int day)
        {
            return Context.Appointments.Where(p => p.AppointmentTime.Day == day);
        }
    }
}