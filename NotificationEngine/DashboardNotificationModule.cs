using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardNotificationService;
using Ninject.Components;
using Ninject.Modules;

namespace NotificationEngine
{
    public class DashboardNotificationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DashboardNotificationEngine>().ToSelf().InSingletonScope();
        }
    }
}
