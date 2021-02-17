// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics
{
    public class ActionableEventLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        private bool IsActionableEvent<TState>(TState state)
        {
            return state is IDictionary<string, object> stateInfo
                    && stateInfo.Keys.Contains("actionableEvent")
                    && stateInfo.Keys.Contains("helpLink");
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsActionableEvent(state))
            {
                string message = formatter(state, exception);
                Console.WriteLine($"Actionable Event:{message}");
                // Log to repository
            }
        }
    }
}
