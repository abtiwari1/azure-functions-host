// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics
{
    public interface IActionableEventRepository
    {
        void AddActionableEvent(DateTime timestamp, string errorCode, LogLevel level, string message, string helpLink);

        IEnumerable<ActionableEvent> GetEvents();

        void FlushLogs();
    }
}