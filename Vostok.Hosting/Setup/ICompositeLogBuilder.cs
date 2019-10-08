﻿using System;
using JetBrains.Annotations;
using Vostok.Logging.Abstractions;

namespace Vostok.Hosting.Setup
{
    [PublicAPI]
    public interface ICompositeLogBuilder
    {
        ICompositeLogBuilder AddLog([NotNull] ILog log);

        //ICompositeLogBuilder AddFileLog([CanBeNull] Action<> fileLogSettings = null);

        ICompositeLogBuilder SetupHerculesLog([NotNull] Action<IHerculesLogBuilder> herculesLogSetup);
    }
}