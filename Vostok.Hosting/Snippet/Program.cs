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