using System;
using Dto;
using Queue;

namespace SmsNotificationEngineService
{
    public class SmsNotificationEngine
    {
        public SmsNotificationEngine()
        {
            QueueConnector.SmsNotificationQueue.OnMessage(x =>
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
