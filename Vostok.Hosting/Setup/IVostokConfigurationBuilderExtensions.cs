﻿using System;
using JetBrains.Annotations;
using Vostok.ClusterConfig.Client.Abstractions;
using Vostok.Configuration.Abstractions;
using Vostok.Configuration.Sources;

namespace Vostok.Hosting.Setup
{
    [PublicAPI]
    public static class IVostokConfigurationBuilderExtensions
    {
        public static IVostokConfigurationSourcesBuilder NestSources([NotNull] this IVostokConfigurationBuilder builder, [NotNull] params string[] scopes)
            => new NestedSourcesBuilder(builder, scopes);

        private class NestedSourcesBuilder : IVostokConfigurationSourcesBuilder
        {
            private readonly IVostokConfigurationBuilder builder;
            private readonly string[] scopes;

            public NestedSourcesBuilder(IVostokConfigurationBuilder builder, string[] scopes)
            {
                this.builder = builder;
                this.scopes = scopes;
            }

            public IVostokConfigurationSourcesBuilder AddSource(IConfigurationSource source)
            {
                builder.AddSource(source.Nest(scopes));
                return this;
            }

            public IVostokConfigurationSourcesBuilder AddSource(Func<IClusterConfigClient, IConfigurationSource> sourceProvider)
            {
                builder.AddSource(ccClient => sourceProvider(ccClient).Nest(scopes));
                return this;
            }

            public IVostokConfigurationSourcesBuilder AddSecretSource(IConfigurationSource source)
            {
                builder.AddSecretSource(source.Nest(scopes));
                return this;
            }
        }
    }
}
