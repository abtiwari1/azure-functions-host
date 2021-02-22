// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Script.Diagnostics
{
    public static class ActionEventLoggerExtensions
    {
        public static void LogActionableEvent(this ILogger logger, LogLevel level, int eventId, string errorCode, string message, string helpLink, Exception exception)
        {
            var stateDict = new Dictionary<string, object>
            {
                { "actionableEvent", string.Empty },
                { "helpLink", helpLink },
                { "errorCode", errorCode }
            };

            logger.Log(level, eventId, stateDict, exception, (state, ex) => message);
        }
    }
}
