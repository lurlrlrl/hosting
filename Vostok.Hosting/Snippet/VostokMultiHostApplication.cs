﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Vostok.Hosting.Models;

namespace Vostok.Hosting.Snippet
{
    public class VostokMultiHostApplication
    {
        private volatile VostokHost vostokHost;

        protected VostokApplicationSettings vostokHostSettings => null;
        
        public string Name { get; }

        public CancellationTokenSource ShutdownTokenSource => vostokHost.ShutdownTokenSource;

        public VostokApplicationState ApplicationState => vostokHost.ApplicationState;

        public IObservable<VostokApplicationState> OnApplicationStateChanged => vostokHost.OnApplicationStateChanged;
        
        public Task<VostokApplicationRunResult> RunAsync() => throw new NotImplementedException();

        public Task StartAsync(VostokApplicationState? stateToAwait = VostokApplicationState.Running) => throw new NotImplementedException();

        // Dispose and delete VostokHost in order to recreate new one later (if needed).
        public Task<VostokApplicationRunResult> StopAsync(bool ensureSuccess = true) => throw new NotImplementedException();
    }
}