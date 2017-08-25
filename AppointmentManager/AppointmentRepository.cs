using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentManager.Data;
using AppointmentManager.Models;

namespace AppointmentManager
{
    public class AppointmentRepository : IAppointmentRepository
    {
        protected IAppointmentDataContext Context { get;}

        public AppointmentRepository(IAppointmentDataContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Returns all appointments 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return Context.Appointments;
        }

        /// <summary>
        /// Default filter on year - can be overriden
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual IEnumerable<Appointment> GetAppointments(int selector)
        {
            return Context.Appointments.Where(p => p.AppointmentTime.Year == selector);
        }



        /// <summary>
        /// Filter by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Appointment GetAppointmentById(Guid id)
        {
            return Context.Appointments.SingleOrDefault(p => p.Id == id);
        }


        /// <summary>
        /// get Appoitnment Details by appointment Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public virtual AppointmentDetail GetAppointmentDetails(Guid appointmentId)
        {
            return Context.AppointmentDetails.SingleOrDefault(p => p.Appointment.Id == appointmentId);
        }

        /// <summary>
        /// Adds new Appointment with Appointment detail
        /// </summary>
        /// <param name="detail"></param>
        public void AddAppointment(AppointmentDetail detail)
        {
            Context.Appointments.Add(detail.Appointment);
            Context.AppointmentDetails.Add(detail);
        }




        /// <summary>
        /// deletes existing appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public bool DeleteAppointment(Appointment appointment)
        {
            return Context.Appointments.Remove(appointment);
        }



        /// <summary>
        /// Updates existing appointment
        /// </summary>
        /// <param name="updatedAppointment"></param>
        public bool UpdateApointment(Appointment updatedAppointment)
        {
            var appointment = Context.Appointments.SingleOrDefault(p => p.Id == updatedAppointment.Id);
            if (appointment == null) return false;
            appointment = updatedAppointment;
            return true;
        }


        /// <summary>
        /// Gets type of provider
        /// </summary>
        /// <returns></returns>
        public virtual Type GetProviderType()
        {
            return GetType();
        }
    }

    /// <summary>
    /// Appointment provider for Month
    /// </summary>
    public class MonthlyAppointmentRepository : AppointmentRepository
    {
        public MonthlyAppointmentRepository(IAppointmentDataContext context) : base(context)
        {
        }

        /// <summary>
        /// Overriden filter for month filtering 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public override IEnumerable<Appointment> GetAppointments(int month)
        {
            return Context.Appointments.Where(p => p.AppointmentTime.Month == month);
        }
    }


    /// <summary>
    /// AppointmentProvider for Day
    /// </summary>
    public class DailyAppointmentRepository : AppointmentRepository
    {
        public DailyAppointmentRepository(IAppointmentDataContext context) : base(context)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public override IEnumerable<Appointment> GetAppointments(int day)
        {
            return Context.Appointments.Where(p => p.AppointmentTime.Day == day);
        }
    }
}