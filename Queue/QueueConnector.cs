using System;
using System.Configuration;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Queue
{
    public class QueueConnector
    {
        // Thread-safe. Recommended that you cache rather than recreating it
        // on every request.
        public QueueClient ProcessRuleQueue { get; set; }
        public QueueClient DashboardNotificationQueue { get; set; }
        public QueueClient SmsNotificationQueue { get; set; }
        public QueueClient EmailNotificationQueue { get; set; }

        // The name of your queue
        private const string ProcessRuleQueueName = "ProcessRuleQueue";
        private const string DashboardNotificationQueueName = "DashboardNotificationQueue";
        private const string SmsNotificationQueueName = "SmsNotificationQueue";
        private const string EmailNotificationQueueName = "EmailNotificationQueue";



        public QueueConnector()
        {
            Initialize();
        }

        private void Initialize()
        {

            var connString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connString);

            // Create the queue if it does not exist already
            if (!namespaceManager.QueueExists(ProcessRuleQueueName))
            {
                namespaceManager.CreateQueue(ProcessRuleQueueName);
            }

            // Create the queue if it does not exist already
            if (!namespaceManager.QueueExists(DashboardNotificationQueueName))
            {
                namespaceManager.CreateQueue(DashboardNotificationQueueName);
            }

            // Create the queue if it does not exist already
            if (!namespaceManager.QueueExists(SmsNotificationQueueName))
            {
                namespaceManager.CreateQueue(SmsNotificationQueueName);
            }

            // Create the queue if it does not exist already
            if (!namespaceManager.QueueExists(EmailNotificationQueueName))
            {
                namespaceManager.CreateQueue(EmailNotificationQueueName);
            }


            // Get a client to the queue
            var messagingFactory = MessagingFactory.Create(
                namespaceManager.Address,
                namespaceManager.Settings.TokenProvider);

            ProcessRuleQueue = messagingFactory.CreateQueueClient(ProcessRuleQueueName);
            DashboardNotificationQueue = messagingFactory.CreateQueueClient(DashboardNotificationQueueName);
            SmsNotificationQueue = messagingFactory.CreateQueueClient(SmsNotificationQueueName);
            EmailNotificationQueue = messagingFactory.CreateQueueClient(EmailNotificationQueueName);
        }
    }
}
