using System;
using System.Collections.Generic;
using System.Diagnostics;
using Dto;
using Microsoft.ServiceBus.Messaging;
using Queue;

namespace SendMessageTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var queueConnector = new QueueConnector();

            Console.WriteLine("Select rule to queue (0 for birthday, 1 for I9)");
            while (true)
            {
                var value = Console.ReadLine();
                if (value != "0" && value != "1")
                {
                    Console.WriteLine("Invalid entry");
                    continue;
                }


                var t = new Stopwatch();
                t.Start();

                var message = new CreateNotifactionMessage
                {
                    RuleType = (RuleType)Convert.ToInt16(value)
                };
                try
                {
                    queueConnector.ProcessRuleQueue.SendAsync(new BrokeredMessage(message));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                t.Stop();
                Console.WriteLine(t.Elapsed);

            }
        }
    }
}
