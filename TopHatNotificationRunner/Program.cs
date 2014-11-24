using DashboardNotificationService;
using Ninject;
using NotificationEngine;
using Queue;
using Topshelf;

namespace TopShelfDashboardNotificationEngineRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load<QueueModule>();
            kernel.Load<DashboardNotificationModule>();
            HostFactory.Run(x =>
            {
                x.Service<DashboardNotificationEngine>(s =>
                {
                    s.ConstructUsing(name => kernel.Get<DashboardNotificationEngine>());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDisplayName("Dashboard Notification Engine Service");
                x.SetServiceName("DashboardNotificationEngineService");
            });
        }
    }
}
