using RuleEngineService;
using Topshelf;

namespace TopShelfRuleEngineRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                
            {
                x.Service<RuleEngine>(s =>                      
                {
                    s.ConstructUsing(name => new RuleEngine());    
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
