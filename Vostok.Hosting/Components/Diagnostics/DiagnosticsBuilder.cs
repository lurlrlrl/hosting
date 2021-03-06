﻿using System;
using Vostok.Commons.Helpers;
using Vostok.Datacenters;
using Vostok.Hercules.Client;
using Vostok.Hosting.Abstractions.Diagnostics;
using Vostok.Hosting.Components.Diagnostics.HealthChecks;
using Vostok.Hosting.Components.Diagnostics.InfoProviders;
using Vostok.Hosting.Setup;
using Vostok.ZooKeeper.Client;

namespace Vostok.Hosting.Components.Diagnostics
{
    internal class DiagnosticsBuilder : IVostokDiagnosticsBuilder, IBuilder<DiagnosticsHub>
    {
        private readonly Customization<HealthTrackerSettings> healthSettingsCustomization;
        private readonly Customization<DiagnosticInfoSettings> infoSettingsCustomization;

        public DiagnosticsBuilder()
        {
            healthSettingsCustomization = new Customization<HealthTrackerSettings>();
            infoSettingsCustomization = new Customization<DiagnosticInfoSettings>();
        }

        public IVostokDiagnosticsBuilder CustomizeInfo(Action<DiagnosticInfoSettings> customization)
        {
            infoSettingsCustomization.AddCustomization(customization ?? throw new ArgumentNullException(nameof(customization)));
            return this;
        }

        public IVostokDiagnosticsBuilder CustomizeHealthTracker(Action<HealthTrackerSettings> customization)
        {
            healthSettingsCustomization.AddCustomization(customization ?? throw new ArgumentNullException(nameof(customization)));
            return this;
        }

        public bool NeedsApplicationMetricsProvider
            => infoSettingsCustomization.Customize(new DiagnosticInfoSettings()).AddApplicationMetricsInfo;

        public DiagnosticsHub Build(BuildContext context)
        {
            var healthTracker = BuildHealthTracker(context);
            var diagnosticInfo = BuildDiagnosticInfo(context, healthTracker);

            return new DiagnosticsHub(diagnosticInfo, healthTracker);
        }

        private HealthTracker BuildHealthTracker(BuildContext context)
        {
            var healthSettings = healthSettingsCustomization.Customize(new HealthTrackerSettings());
            var healthTracker = new HealthTracker(healthSettings.ChecksPeriod, context.Log);

            if (healthSettings.AddDatacenterWhitelistCheck)
                healthTracker.RegisterCheck("Datacenter whitelist", new DatacenterWhitelistCheck(context.Datacenters ?? new EmptyDatacenters()));

            if (healthSettings.AddThreadPoolStarvationCheck)
                healthTracker.RegisterCheck("Thread pool", new ThreadPoolStarvationCheck());

            if (healthSettings.AddZooKeeperConnectionCheck && context.ZooKeeperClient is ZooKeeperClient realClient)
                healthTracker.RegisterCheck("ZooKeeper connection", new ZooKeeperConnectionCheck(realClient));

            return healthTracker;
        }

        private DiagnosticInfo BuildDiagnosticInfo(BuildContext context, IHealthTracker healthTracker)
        {
            var infoSettings = infoSettingsCustomization.Customize(new DiagnosticInfoSettings());
            var info = new DiagnosticInfo();

            if (infoSettings.AddEnvironmentInfo)
                info.RegisterProvider(CreateEntry("environment-info"), new EnvironmentInfoProvider(context.Datacenters));

            if (infoSettings.AddSystemMetricsInfo)
                info.RegisterProvider(CreateEntry("system-metrics"), new SystemMetricsProvider());

            if (infoSettings.AddLoadedAssembliesInfo)
                info.RegisterProvider(CreateEntry("loaded-assemblies"), new LoadedAssembliesProvider());

            if (infoSettings.AddHealthChecksInfo)
                info.RegisterProvider(CreateEntry("health-checks"), new HealthChecksInfoProvider(healthTracker));

            if (infoSettings.AddConfigurationInfo)
                info.RegisterProvider(CreateEntry("configuration"), new ConfigurationInfoProvider(context.ConfigurationSource));

            if (infoSettings.AddHerculesSinkInfo && context.HerculesSink is HerculesSink realSink)
                info.RegisterProvider(CreateEntry("hercules-sink"), new HerculesSinkInfoProvider(realSink));

            if (infoSettings.AddApplicationMetricsInfo && context.MetricsInfoProvider != null)
                info.RegisterProvider(CreateEntry("application-metrics"), context.MetricsInfoProvider);

            if (infoSettings.AddApplicationInfo)
                info.RegisterProvider(
                    CreateEntry("application-info"),
                    new ApplicationInfoProvider(
                        context.ApplicationIdentity,
                        context.ApplicationLimits,
                        context.ApplicationReplication));

            return info;
        }

        private static DiagnosticEntry CreateEntry(string name)
            => new DiagnosticEntry("hosting", name);
    }
}
