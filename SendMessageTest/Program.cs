using System;
using Dto;
using Microsoft.ServiceBus.Messaging;
using Queue;

namespace SendMessageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select rule to queue (0 for birthday, 1 for I9)");
            while (true)
            {
                var value = Console.ReadLine();
                if (value != "0" && value != "1")
                {
                    Console.WriteLine("Invalid entry");
                    continue;
                }
                var message = new CreateNotifactionMessage
                {
                    RuleType = (RuleType)Convert.ToInt16(value)
                };
                QueueConnector.ProcessRuleQueue.Send(new BrokeredMessage(message));
            }
        }
    }
}
