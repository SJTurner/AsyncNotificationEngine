using System;
using Dto;
using Queue;

namespace EmailNotificationService
{
    public class EmailNotificationEngine
    {
        public EmailNotificationEngine()
        {
            QueueConnector.EmailNotificationQueue.OnMessage(x =>
            {
                var message = x.GetBody<string>();
                Console.WriteLine(message);
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
