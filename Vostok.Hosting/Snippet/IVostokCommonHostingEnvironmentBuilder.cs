using System;
using JetBrains.Annotations;
using Vostok.Hosting.Components.SystemMetrics;
using Vostok.Hosting.Setup;

namespace Vostok.Hosting.Snippet
{
    public interface IVostokCommonHostingEnvironmentBuilder
    {
        IVostokCommonHostingEnvironmentBuilder SetupClusterConfigClient(
            [NotNull] Action<IVostokClusterConfigClientBuilder> setup);

        IVostokCommonHostingEnvironmentBuilder SetupHerculesSink([NotNull] Action<IVostokHerculesSinkBuilder> setup);

        IVostokCommonHostingEnvironmentBuilder SetupDatacenters([NotNull] Action<IVostokDatacentersBuilder> setup);

        IVostokCommonHostingEnvironmentBuilder SetupZooKeeperClient(
            [NotNull] Action<IVostokZooKeeperClientBuilder> setup);

        IVostokCommonHostingEnvironmentBuilder SetupServiceLocator([NotNull] Action<IVostokServiceLocatorBuilder> setup);

        IVostokCommonHostingEnvironmentBuilder SetupHostExtensions([NotNull] Action<IVostokHostExtensionsBuilder> setup);

        IVostokCommonHostingEnvironmentBuilder SetupSystemMetrics([NotNull] Action<SystemMetricsSettings> setup);
    }
}