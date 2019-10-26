﻿using System;
using Vostok.Hosting.Abstractions;

namespace Vostok.Hosting.Components.Application
{
    internal class ApplicationReplicationInfo : IVostokApplicationReplicationInfo
    {
        public ApplicationReplicationInfo(int instanceIndex, int instancesCount)
        {
            if (!(0 <= instanceIndex && instanceIndex < instancesCount))
                throw new ArgumentOutOfRangeException($"Instance index ({instanceIndex}) not in range [0, {instancesCount - 1}].");

            InstanceIndex = instanceIndex;
            InstancesCount = instancesCount;
        }

        public int InstanceIndex { get; }
        public int InstancesCount { get; }
    }
}