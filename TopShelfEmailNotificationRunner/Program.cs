using EmailNotificationService;
using Topshelf;

namespace TopShelfEmailNotificationRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<EmailNotificationEngine>(s =>
                {
                    s.ConstructUsing(name => new EmailNotificationEngine());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDisplayName("Email Notification Engine Service");
                x.SetServiceName("EmailEngineService");
            });
        }
    }
}