using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Queue
{
    public static class QueueConnector
    {
        // Thread-safe. Recommended that you cache rather than recreating it
        // on every request.
        public static QueueClient ProcessRuleQueue;
        public static QueueClient DashboardNotificationQueue;
        public static QueueClient SmsNotificationQueue;
        public static QueueClient EmailNotificationQueue;

        // Obtain these values from the Management Portal
        private const string Namespace = "thenoblehardymen";
        private const string IssuerName = "RootManageSharedAccessKey";
        private const string IssuerKey = "";

        // The name of your queue
        private const string ProcessRuleQueueName = "ProcessRuleQueue";
        private const string DashboardNotificationQueueName = "DashboardNotificationQueue";
        private const string SmsNotificationQueueName = "SmsNotificationQueue";
        private const string EmailNotificationQueueName = "EmailNotificationQueue";

        public static NamespaceManager CreateNamespaceManager()
        {
            // Create the namespace manager which gives you access to
            // management operations
            var uri = ServiceBusEnvironment.CreateServiceUri(
                "sb", Namespace, String.Empty);
            var tP = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                IssuerName, IssuerKey);
            return new NamespaceManager(uri, tP);
        }

        static QueueConnector()
        {
            Initialize();
        }

        public static void Initialize()
        {
            // Using Http to be friendly with outbound firewalls
            ServiceBusEnvironment.SystemConnectivity.Mode =
                ConnectivityMode.Http;

            // Create the namespace manager which gives you access to 
            // management operations
            var namespaceManager = CreateNamespaceManager();

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
