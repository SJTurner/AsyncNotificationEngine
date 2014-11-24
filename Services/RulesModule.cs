using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Ninject.Modules;
using Rules;

namespace Services
{
    public class RulesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRule>().To<BirthdayRule>().InTransientScope().Named(RuleType.Birthday.ToString());
            Bind<IRule>().To<I9Rule>().InTransientScope().Named(RuleType.I9.ToString());
        }
    }
}
