using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Microsoft.ServiceBus.Messaging;
using QueryProviders;
using Queue;

namespace Rules
{
    public class I9Rule : IRule
    {
        private const string MessageTemplate = "An I9 expiration reminder was sent to employee {0} from company {1}";
        private readonly IRuleQueryProvider _i9RuleQueryProvider;
        public I9Rule()
        {
            _i9RuleQueryProvider = new I9RuleQueryProvider();
        }
        public IEnumerable<CompanyRuleConfiguaration> GetCompanyRuleConfiguarations()
        {
            return _i9RuleQueryProvider.GetCompanyRuleConfiguarations();
        }

        public void Execute(CompanyRuleConfiguaration config)
        {
            var employees =
                _i9RuleQueryProvider.GetNotificationRecipients(config).ToList();
            if (!employees.Any()) return;
            switch (config.NotificationType)
            {
                case NotificationType.All:
                    //Have to create a new set of messages for each queue or it will throw a message already consumed exception
                    QueueConnector.DashboardNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    QueueConnector.EmailNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    QueueConnector.SmsNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;
                case NotificationType.Dashboard:
                    QueueConnector.DashboardNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;
                case NotificationType.Email:
                    QueueConnector.EmailNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;
                case NotificationType.Sms:
                    QueueConnector.SmsNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;

            }
        }
    }
}
