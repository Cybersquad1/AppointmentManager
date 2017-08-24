using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppointmentManager;
using AppointmentManager.Data;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace AppointmentCalendar
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            var context = container.RegisterType<IAppointmentDataContext, AppointmentDataContext>();
            container.RegisterType<IAppointmentProviderContext, AppointmentProviderContext>(new InjectionConstructor(new ResolvedParameter<IAppointmentDataContext>()));
            return container;
        }

        

    }
}