using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Components.Shutdown;
using Vostok.Hosting.Helpers;
using Vostok.Hosting.Setup;

namespace Vostok.Hosting.Snippet
{
    public class VostokApplicationSettings
    {
        public VostokApplicationSettings([NotNull] IVostokApplication application, [NotNull] string applicationName, [NotNull] VostokHostingEnvironmentSetup environmentSetup)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
            ApplicationName = applicationName ?? throw new ArgumentNullException(nameof(applicationName));
            EnvironmentSetup = environmentSetup ?? throw new ArgumentNullException(nameof(environmentSetup));
        }
        
        // Application to run.
        public IVostokApplication Application { get; set; }
        
        public string ApplicationName { get; set; }

        // Environment setup.
        public VostokHostingEnvironmentSetup EnvironmentSetup { get; set; }

        // public bool ConfigureStaticProviders { get; set; } = true;

        public bool LogApplicationConfiguration { get; set; }

        public bool WarmupConfiguration { get; set; } = true;

        public TimeSpan ShutdownTimeout { get; set; } = ShutdownConstants.DefaultShutdownTimeout;

        public TimeSpan BeaconShutdownTimeout { get; set; } = ShutdownConstants.DefaultBeaconShutdownTimeout;

        public bool BeaconShutdownWaitEnabled { get; set; } = true;

        // Actions that will be executed before initialization.
        public List<Action<IVostokHostingEnvironment>> BeforeInitializeApplication { get; set; } = new List<Action<IVostokHostingEnvironment>>();
    }
}