using Ninject.Modules;
using RuleEngineService;

namespace NotificationGeneratorService
{
    public class RulesEngineModule : NinjectModule
    {
        public override void Load()
        {
           Bind<RuleEngine>().ToSelf().InSingletonScope();
        }
    }
}
