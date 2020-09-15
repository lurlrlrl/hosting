using System;
using System.Threading;
using JetBrains.Annotations;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Setup;

namespace Vostok.Hosting.Snippet
{
    public interface IVostokIndividualHostingEnvironmentBuilder
    {
        IVostokIndividualHostingEnvironmentBuilder SetupShutdownToken(CancellationToken shutdownToken);
        IVostokIndividualHostingEnvironmentBuilder SetupShutdownTimeout(TimeSpan shutdownTimeout);

        IVostokIndividualHostingEnvironmentBuilder SetupConfiguration([NotNull] Action<IVostokConfigurationBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupConfiguration([NotNull] Action<IVostokConfigurationBuilder, IVostokConfigurationSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupLog([NotNull] Action<IVostokCompositeLogBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupLog([NotNull] Action<IVostokCompositeLogBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupApplicationIdentity([NotNull] Action<IVostokApplicationIdentityBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupApplicationIdentity([NotNull] Action<IVostokApplicationIdentityBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupApplicationLimits([NotNull] Action<IVostokApplicationLimitsBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupApplicationLimits([NotNull] Action<IVostokApplicationLimitsBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupApplicationReplicationInfo([NotNull] Action<IVostokApplicationReplicationInfoBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupApplicationReplicationInfo([NotNull] Action<IVostokApplicationReplicationInfoBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupTracer([NotNull] Action<IVostokTracerBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupTracer([NotNull] Action<IVostokTracerBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupMetrics([NotNull] Action<IVostokMetricsBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupMetrics([NotNull] Action<IVostokMetricsBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupDiagnostics([NotNull] Action<IVostokDiagnosticsBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupDiagnostics([NotNull] Action<IVostokDiagnosticsBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupServiceBeacon([NotNull] Action<IVostokServiceBeaconBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupServiceBeacon([NotNull] Action<IVostokServiceBeaconBuilder, IVostokHostingEnvironmentSetupContext> setup);

        IVostokIndividualHostingEnvironmentBuilder SetupHostExtensions([NotNull] Action<IVostokHostExtensionsBuilder> setup);
        IVostokIndividualHostingEnvironmentBuilder SetupHostExtensions([NotNull] Action<IVostokHostExtensionsBuilder, IVostokHostingEnvironment> setup);
    }
}