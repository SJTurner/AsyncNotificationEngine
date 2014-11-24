using Ninject;
using Queue;
using SmsNotificationEngineService;
using Topshelf;

namespace TopShelfSmsNotificationRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load<QueueModule>();
            kernel.Load<SmsNotificationModule>();
            HostFactory.Run(x =>
            {
                x.Service<SmsNotificationEngine>(s =>
                {
                    s.ConstructUsing(name => kernel.Get<SmsNotificationEngine>());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDisplayName("Sms Notification Engine Service");
                x.SetServiceName("SmsEngineService");
            });
        }
    }
}

