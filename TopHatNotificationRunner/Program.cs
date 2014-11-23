using DashboardNotificationService;
using Topshelf;

namespace TopShelfDashboardNotificationEngineRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<DashboardNotificationEngine>(s =>
                {
                    s.ConstructUsing(name => new DashboardNotificationEngine());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDisplayName("Dashboard Notification Engine Service");
                x.SetServiceName("NotificationEngineService");
            });
        }
    }
}
