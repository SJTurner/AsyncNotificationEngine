using SmsNotificationEngineService;
using Topshelf;

namespace TopShelfSmsNotificationRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SmsNotificationEngine>(s =>
                {
                    s.ConstructUsing(name => new SmsNotificationEngine());
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

