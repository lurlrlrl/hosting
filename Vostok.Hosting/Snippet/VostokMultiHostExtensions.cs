using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vostok.Hosting.Models;

namespace Vostok.Hosting.Snippet
{
    public static class VostokMultiHostExtensions
    {
        public static Task<VostokApplicationRunResult> RunApp(this VostokMultiHost host, VostokApplicationSettings settings)
        {
            // Can be ran only after VostokMultiHost start.
            return host.AddApp(settings).RunAsync();
        }
        
        public static Task<VostokApplicationRunResult> StartApp(this VostokMultiHost host, VostokApplicationSettings settings)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        public static Task<VostokApplicationRunResult> RestartApp(this VostokMultiHost host, string appName)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        public static Task<VostokApplicationRunResult> StopApp(this VostokMultiHost host, string appName)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        public static Task<VostokApplicationRunResult> StartSequentially(this VostokMultiHost host, IEnumerable<VostokApplicationSettings> apps)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        public static Task<VostokApplicationRunResult> StartSequentially(this VostokMultiHost host, params VostokApplicationSettings[] apps)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        public static Task<VostokApplicationRunResult> StartInParallel(this VostokMultiHost host, IEnumerable<VostokApplicationSettings> apps)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        public static Task<VostokApplicationRunResult> StartInParallel(this VostokMultiHost host, params VostokApplicationSettings[] apps)
        {
            // Can be ran only after VostokMultiHost start.
            throw new NotImplementedException();
        }
        
        // ...
    }
}