using Dto;
using Microsoft.ServiceBus.Messaging;
using Queue;
using Rules;

namespace RuleEngineService
{
    public class RuleEngine 
    {
        public RuleEngine()
        {
            //Each rule type should be its own service instead of a single services for all so we can scale as needed
            //also instead of reading the list of company configurations in the rule processor we should be passing in
            //a seperate message for each company configuration so we can scale up the rule engine services and process
            //companies in parallel. 
            QueueConnector.ProcessRuleQueue.OnMessage(x =>
            {
                var message = x.GetBody<CreateNotifactionMessage>();
                var rule = GetRule(message.RuleType);
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

        private IRule GetRule(RuleType type)
        {
            switch (type)
            {
                case RuleType.Birthday:
                    return new BirthdayRule();
                case RuleType.I9:
                    return new I9Rule();
                default:
                    return null;
            }
        }
  
    }
}
