using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace EmailNotificationService
{
    public class EmailNotificationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<EmailNotificationEngine>().ToSelf().InSingletonScope();
        }
    }
}
