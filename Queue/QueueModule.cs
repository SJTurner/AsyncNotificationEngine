using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Queue
{
    public class QueueModule : NinjectModule
    {
        public override void Load()
        {
            Bind<QueueConnector>().ToSelf().InSingletonScope();
        }
    }
}
