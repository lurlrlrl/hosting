﻿using System;
using System.Threading;
using JetBrains.Annotations;
using Vostok.Clusterclient.Core;
using Vostok.ClusterConfig.Client.Abstractions;
using Vostok.Commons.Collections;
using Vostok.Configuration.Abstractions;
using Vostok.Context;
using Vostok.Hercules.Client.Abstractions;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Components.Application;
using Vostok.Logging.Abstractions;
using Vostok.ServiceDiscovery.Abstractions;
using Vostok.Tracing.Abstractions;

// ReSharper disable NotNullMemberIsNotInitialized

namespace Vostok.Hosting
{
    internal class VostokHostingEnvironment : IVostokHostingEnvironment, IDisposable
    {
        private readonly Func<(int instanceIndex, int instancesCount)> applicationReplicationInfoProvider;
        private readonly CachingTransform<(int, int), IVostokApplicationReplicationInfo> applicationReplicationInfoTransform;
        private readonly Action dispose;

        internal VostokHostingEnvironment(
            CancellationToken shutdownToken,
            [NotNull] IVostokApplicationIdentity applicationIdentity,
            [NotNull] IVostokApplicationLimits applicationLimits,
            [NotNull] Func<(int instanceIndex, int instancesCount)> applicationReplicationInfoProvider,
            [NotNull] IVostokApplicationMetrics metrics,
            [NotNull] ILog log,
            [NotNull] ITracer tracer,
            [NotNull] IHerculesSink herculesSink,
            [NotNull] IConfigurationSource configurationSource,
            [NotNull] IConfigurationProvider configurationProvider,
            [NotNull] IClusterConfigClient clusterConfigClient,
            [NotNull] IServiceBeacon serviceBeacon,
            [NotNull] IServiceLocator serviceLocator,
            [NotNull] IContextGlobals contextGlobals,
            [NotNull] IContextProperties contextProperties,
            [NotNull] IContextConfiguration contextConfiguration,
            [NotNull] ClusterClientSetup clusterClientSetup,
            [NotNull] IVostokHostExtensions hostExtensions,
            [NotNull] Action dispose)
        {
            ShutdownToken = shutdownToken;
            ApplicationIdentity = applicationIdentity ?? throw new ArgumentNullException(nameof(applicationIdentity));
            ApplicationLimits = applicationLimits ?? throw new ArgumentNullException(nameof(applicationLimits));

            this.applicationReplicationInfoProvider = applicationReplicationInfoProvider ?? throw new ArgumentNullException(nameof(applicationReplicationInfoProvider));
            applicationReplicationInfoTransform = new CachingTransform<(int, int), IVostokApplicationReplicationInfo>(tuple => new ApplicationReplicationInfo(tuple.Item1, tuple.Item2));

            Metrics = metrics ?? throw new ArgumentNullException(nameof(metrics));
            Log = log ?? throw new ArgumentNullException(nameof(log));
            Tracer = tracer ?? throw new ArgumentNullException(nameof(tracer));
            HerculesSink = herculesSink ?? throw new ArgumentNullException(nameof(herculesSink));
            ConfigurationSource = configurationSource ?? throw new ArgumentNullException(nameof(configurationSource));
            ConfigurationProvider = configurationProvider ?? throw new ArgumentNullException(nameof(configurationProvider));
            ClusterConfigClient = clusterConfigClient ?? throw new ArgumentNullException(nameof(clusterConfigClient));
            ServiceBeacon = serviceBeacon ?? throw new ArgumentNullException(nameof(serviceBeacon));
            ServiceLocator = serviceLocator ?? throw new ArgumentNullException(nameof(serviceLocator));
            ContextGlobals = contextGlobals ?? throw new ArgumentNullException(nameof(contextGlobals));
            ContextProperties = contextProperties ?? throw new ArgumentNullException(nameof(contextProperties));
            ContextConfiguration = contextConfiguration ?? throw new ArgumentNullException(nameof(contextConfiguration));
            ClusterClientSetup = clusterClientSetup ?? throw new ArgumentNullException(nameof(clusterClientSetup));
            HostExtensions = hostExtensions ?? throw new ArgumentNullException(nameof(hostExtensions));
            this.dispose = dispose ?? throw new ArgumentNullException(nameof(dispose));
        }

        public CancellationToken ShutdownToken { get; }
        public IVostokApplicationIdentity ApplicationIdentity { get; }
        public IVostokApplicationLimits ApplicationLimits { get; }
        public IVostokApplicationReplicationInfo ApplicationReplicationInfo => applicationReplicationInfoTransform.Get(applicationReplicationInfoProvider());
        public IVostokApplicationMetrics Metrics { get; }
        public ILog Log { get; }
        public ITracer Tracer { get; }
        public IHerculesSink HerculesSink { get; }
        public IConfigurationSource ConfigurationSource { get; }
        public IConfigurationProvider ConfigurationProvider { get; }
        public IClusterConfigClient ClusterConfigClient { get; }
        public IServiceBeacon ServiceBeacon { get; }
        public IServiceLocator ServiceLocator { get; }
        public IContextGlobals ContextGlobals { get; }
        public IContextProperties ContextProperties { get; }
        public IContextConfiguration ContextConfiguration { get; }
        public ClusterClientSetup ClusterClientSetup { get; }
        public IVostokHostExtensions HostExtensions { get; }

        public void Dispose()
        {
            dispose();
        }
    }
}