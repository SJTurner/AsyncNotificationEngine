using Dto;
using Ninject;
using NotificationGeneratorService;
using Queue;
using RuleEngineService;
using Rules;
using Services;
using Topshelf;

namespace TopShelfRuleEngineRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            kernel.Load<QueueModule>();
            kernel.Load<RulesEngineModule>();
            kernel.Load<RulesModule>();

            HostFactory.Run(x =>                                
            {
                x.Service<RuleEngine>(s =>                      
                {
                    s.ConstructUsing(name => kernel.Get<RuleEngine>());    
                    s.WhenStarted(tc => tc.Start());             
                    s.WhenStopped(tc => tc.Stop());              
                });
                x.RunAsLocalSystem();

                x.SetDisplayName("Rule Engine  Service");
                x.SetServiceName("RuleEngineService");                       
            });                                          
        }
    }
}
