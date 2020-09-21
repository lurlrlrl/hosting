using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Components.Shutdown;
using Vostok.Hosting.Helpers;
using Vostok.Hosting.Setup;

namespace Vostok.Hosting.Snippet
{
    public class VostokMultiHostSettings
    {
        public VostokMultiHostSettings(IVostokApplication app, Action<IVostokHostingEnvironmentBuilder> builder)
        {
            throw new NotImplementedException();
        }

        public IVostokApplication Application { get; set; }

        public VostokHostingEnvironmentSetup EnvironmentSetup { get; set; }

        // public bool ConfigureStaticProviders { get; set; } = true;

        public bool ConfigureThreadPool { get; set; } = true;
        
        public int ThreadPoolTuningMultiplier { get; set; } = 32;

        // public bool WarmupZooKeeper { get; set; } = true;

        // public List<Action<IVostokHostingEnvironment>> BeforeInitializeApplication { get; set; } = new List<Action<IVostokHostingEnvironment>>();
    }
}