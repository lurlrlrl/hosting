using System.Threading.Tasks;
using Vostok.Hosting.Abstractions;

namespace Vostok.Hosting.Snippet
{
    internal class Program
    {
        private const string FirstApp = "FirstApp";
        private const string SecondApp = "SecondApp";

        private static async Task Main(string[] args)
        {
            var host = new VostokMultiHost(
                config =>
                {
                    // config
                    //    .SetupDatacenters()
                    //    .SetupHerculesSink()
                    //    .SetupHostExtensions()
                    //    .SetupServiceLocator()
                    //    .SetupSystemMetrics()
                    //    .SetupClusterConfigClient()
                    //    .SetupZooKeeperClient();
                },
                new VostokMultiHostSettings(
                    new App(),
                    FirstApp,
                    config =>
                    {
                        // config
                        //    .SetupConfiguration()
                        //    .SetupDiagnostics()
                        //    .SetupLog();
                    }
                ),
                new VostokMultiHostSettings(
                    new App(),
                    SecondApp,
                    config =>
                    {
                        // Do not setup
                    })
                // We can add as many apps as we want.
            );

            await host.WithParallelLaunch().RunAsync();

            host.GetApp(FirstApp).Stop();
            host.GetApp(FirstApp).Run();
        }
    }

    public class App : IVostokApplication
    {
        public Task InitializeAsync(IVostokHostingEnvironment environment)
        {
            return Task.CompletedTask;
        }

        public Task RunAsync(IVostokHostingEnvironment environment)
        {
            return Task.Delay(60 * 1000);
        }
    }
}