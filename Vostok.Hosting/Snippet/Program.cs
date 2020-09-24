using System.Collections.Generic;
using System.Threading.Tasks;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Setup;

namespace Vostok.Hosting.Snippet
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = new VostokMultiHost(
                new VostokMultiHostSettings(
                    builder => {})
                );

            
            var vostokHost = new VostokHost(new VostokHostSettings(null, null));

            await host.StartAsync();

            await host.RunApp(new VostokApplicationSettings(new App(), "", builder => {}));
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