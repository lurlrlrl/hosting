﻿using System;
using System.Threading;
using JetBrains.Annotations;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Abstractions.Wrappers;

namespace Vostok.Hosting.Components.Log
{
    [PublicAPI]
    public class SubstitutableLog : ILog
    {
        private volatile ILog baseLog = new BufferedLog();

        public bool IsBuffering => baseLog is BufferedLog;

        public void Log(LogEvent @event) => baseLog.Log(@event);

        public bool IsEnabledFor(LogLevel level) => baseLog.IsEnabledFor(level);

        public ILog ForContext(string context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new SourceContextWrapper(this, context);
        }

        public void SubstituteWith(ILog newLog)
        {
            var oldLog = Interlocked.Exchange(ref baseLog, newLog);
            if (oldLog is BufferedLog bufferedLog)
            {
                bufferedLog.SendBufferedEvents(newLog);
            }
        }
    }
}