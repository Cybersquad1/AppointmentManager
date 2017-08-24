namespace AppointmentManager
{
    public interface IAppointmentProviderContext
    {
        IAppointmentProvider GetAppointmentProvider(AppointmentSelector selector = default(AppointmentSelector));
    }
}