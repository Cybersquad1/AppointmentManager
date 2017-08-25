namespace AppointmentManager
{
    public interface IAppointmentRepositoryContext
    {
        IAppointmentRepository GetAppointmentRepository(AppointmentSelector selector = default(AppointmentSelector));
    }
}