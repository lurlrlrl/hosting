﻿using System;
using JetBrains.Annotations;
using Vostok.ClusterConfig.Client.Abstractions;
using Vostok.Configuration;
using Vostok.Configuration.Abstractions;
using Vostok.Configuration.Abstractions.Merging;
using Vostok.Configuration.Printing;

namespace Vostok.Hosting.Setup
{
    [PublicAPI]
    public interface IVostokConfigurationBuilder
    {
        IVostokConfigurationBuilder AddSource([NotNull] IConfigurationSource source);

        IVostokConfigurationBuilder SetupSources([NotNull] Action<IConfigurationProvider, IConfigurationSource, IClusterConfigClient> sourcesSetup);

        IVostokConfigurationBuilder CustomizeMergeSourcesSettings([NotNull] Action<SettingsMergeOptions> settingsCustomization);

        IVostokConfigurationBuilder CustomizeConfigurationProviderSettings([NotNull] Action<ConfigurationProviderSettings> settingsCustomization);

        IVostokConfigurationBuilder CustomizePrintSettings([NotNull] Action<PrintSettings> settingsCustomization);
    }
}