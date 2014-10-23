﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class HostBindingContext
    {
        private readonly IBackgroundExceptionDispatcher _backgroundExceptionDispatcher;
        private readonly IBindingProvider _bindingProvider;

        public HostBindingContext(
            IBackgroundExceptionDispatcher backgroundExceptionDispatcher,
            IBindingProvider bindingProvider)
        {
            _backgroundExceptionDispatcher = backgroundExceptionDispatcher;
            _bindingProvider = bindingProvider;
        }

        public IBackgroundExceptionDispatcher BackgroundExceptionDispatcher
        {
            get { return _backgroundExceptionDispatcher; }
        }

        public IBindingProvider BindingProvider
        {
            get { return _bindingProvider; }
        }

        public IBlobWrittenWatcher BlobWrittenWatcher { get; set; }

        public IMessageEnqueuedWatcher MessageEnqueuedWatcher { get; set; }
    }
}
