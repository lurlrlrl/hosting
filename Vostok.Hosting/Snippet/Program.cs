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
            
            // TODO: Configuration shortcuts. For instance:
            // - Replication
            // - Configure by default
            // - SetupForKontur
            // ...
            
            // To discuss: 
            // 1) ApplicationIdentity instead of name.
            // 2) Track applications by their ApplicationIdentity, not by name. (Group them by Project, Subproject...)
            // 3) VostokMultiHost builder individual settings could probably be considered as default for apps, but can be overriden in individual builders.
            // 4) Why doesn't ApplicationIdentity explicitly belong to VostokHostSettings? (Why is it implicitly created in builder?)
            // 5) StaticProviders
            // 6) Automatic ApplicationIdentity setter?

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
            return Task.CompletedTask;
        }
    }
}