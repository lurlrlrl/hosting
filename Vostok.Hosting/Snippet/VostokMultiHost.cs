using System;
using System.Threading.Tasks;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Models;

namespace Vostok.Hosting.Snippet
{
    public class VostokMultiHost
    {
        public VostokMultiHost(Action<IVostokCommonHostingEnvironmentBuilder> builder, params VostokMultiHostSettings[] apps)
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

        public VostokMultiHost WithSequentialLaunch()
        {
            return this;
        }

        public VostokMultiHost WithParallelLaunch()
        {
            return this;
        }
    }

    public class VostokMultiHostSettings
    {
        public VostokMultiHostSettings(IVostokApplication app, string appName, Action<IVostokIndividualHostingEnvironmentBuilder> builder)
        {
            throw new NotImplementedException();
        }
    }
}