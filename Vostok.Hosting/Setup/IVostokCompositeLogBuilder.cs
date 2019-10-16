﻿using System;
using JetBrains.Annotations;
using Vostok.Logging.Abstractions;

namespace Vostok.Hosting.Setup
{
    [PublicAPI]
    public interface IVostokCompositeLogBuilder
    {
        IVostokCompositeLogBuilder AddLog([NotNull] ILog log);

        IVostokCompositeLogBuilder SetupFileLog();
        IVostokCompositeLogBuilder SetupFileLog([NotNull] Action<IVostokFileLogBuilder> fileLogSetup);

        IVostokCompositeLogBuilder SetupConsoleLog();
        IVostokCompositeLogBuilder SetupConsoleLog([NotNull] Action<IVostokConsoleLogBuilder> consoleLogSetup);

        IVostokCompositeLogBuilder SetupHerculesLog([NotNull] Action<IVostokHerculesLogBuilder> herculesLogSetup);
    }
}