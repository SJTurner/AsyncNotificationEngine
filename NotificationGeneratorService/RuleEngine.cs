using Dto;
using Microsoft.ServiceBus.Messaging;
using Ninject.Syntax;
using Queue;
using Rules;
using Ninject;

namespace RuleEngineService
{
    public class RuleEngine
    {

        public RuleEngine(QueueConnector queueConnector, IResolutionRoot dependencyContainer)
        {
            //Each rule type should be its own service instead of a single services for all so we can scale as needed
            //also instead of reading the list of company configurations in the rule processor we should be passing in
            //a seperate message for each company configuration so we can scale up the rule engine services and process
            //companies in parallel. 
            queueConnector.ProcessRuleQueue.OnMessage(x =>
            {
                var message = x.GetBody<CreateNotifactionMessage>();
                var rule = dependencyContainer.Get<IRule>(message.RuleType.ToString());
                foreach (var config in rule.GetCompanyRuleConfiguarations())
                {
                    rule.Execute(config);
                }
            });

        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
  
    }
}
