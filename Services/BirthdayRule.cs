using System;
using System.Collections.Generic;
using System.Linq;
using Dto;
using Microsoft.ServiceBus.Messaging;
using QueryProviders;
using Queue;

namespace Rules
{

    public class BirthdayRule : IRule
    {
        private const string MessageTemplate = "A Birthday reminder was sent to employee {0} from company {1}";
        private readonly IRuleQueryProvider _birthdayRuleQueryProvider;
        private readonly QueueConnector _queueConnector;
        public BirthdayRule(QueueConnector queueConnector)
        {
            _queueConnector = queueConnector;
            _birthdayRuleQueryProvider = new BirthdayRuleQueryProvider();
        }
        public IEnumerable<CompanyRuleConfiguaration> GetCompanyRuleConfiguarations()
        {
            return _birthdayRuleQueryProvider.GetCompanyRuleConfiguarations();
        }

        public void Execute(CompanyRuleConfiguaration config)
        {
            var employees = _birthdayRuleQueryProvider.GetNotificationRecipients(config).ToList();
            if (!employees.Any()) return;
            switch (config.NotificationType)
            {
                case NotificationType.All:
                    //Have to create a new set of messages for each queue or it will throw a message already consumed exception
                    _queueConnector.DashboardNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    _queueConnector.EmailNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    _queueConnector.SmsNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;
                case NotificationType.Dashboard:
                    _queueConnector.DashboardNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;
                case NotificationType.Email:
                    _queueConnector.EmailNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;
                case NotificationType.Sms:
                    _queueConnector.SmsNotificationQueue.SendBatchAsync(employees.Select(x => new BrokeredMessage(string.Format(MessageTemplate, x.EmployeeId, x.CompanyId))));
                    break;

            }
        }
    }
}
