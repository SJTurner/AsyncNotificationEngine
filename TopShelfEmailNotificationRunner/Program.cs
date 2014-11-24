using EmailNotificationService;
using Ninject;
using Queue;
using Topshelf;

namespace TopShelfEmailNotificationRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load<QueueModule>();
            kernel.Load<EmailNotificationModule>();

            HostFactory.Run(x =>
            {
                x.Service<EmailNotificationEngine>(s =>
                {
                    s.ConstructUsing(name => kernel.Get<EmailNotificationEngine>());
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