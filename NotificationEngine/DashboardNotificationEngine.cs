using System;
using Dto;
using Queue;

namespace DashboardNotificationService
{
    public class DashboardNotificationEngine
    {
        public DashboardNotificationEngine()
        {
            QueueConnector.DashboardNotificationQueue.OnMessage(x =>
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
