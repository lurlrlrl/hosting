using System;
using System.Threading.Tasks;
using Vostok.Hosting.Models;
using Vostok.Hosting.Setup;

namespace Vostok.Hosting.Snippet
{
    public class VostokMultiHost
    {
        public VostokMultiHost(Action<IVostokHostingEnvironmentBuilder> builder, params VostokMultiHostSettings[] apps)
        {
            throw new NotImplementedException();
        }

        public virtual Task<VostokApplicationRunResult> RunAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VostokApplicationRunResult> StopAsync(bool ensureSuccess = true)
        {
            throw new NotImplementedException();
        }

        public VostokHost GetApp(string appName) => throw new NotImplementedException();
    }
}