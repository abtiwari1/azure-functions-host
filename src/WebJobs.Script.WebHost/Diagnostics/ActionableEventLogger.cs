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
        private const string ErrorCode = "errorCode";
        private const string HelpLink = "helpLink";
        private readonly IActionableEventRepository _actionableEventRepository;

        public ActionableEventLogger(IActionableEventRepository actionableEventRepository)
        {
            _actionableEventRepository = actionableEventRepository;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        private bool IsActionableEvent(IDictionary<string, object> state)
        {
            return state.Keys.Contains("actionableEvent") && state.Keys.Contains("helpLink");
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (state is IDictionary<string, object> stateInfo && IsActionableEvent(stateInfo))
            {
                string message = formatter(state, exception);
                Console.WriteLine($"Actionable Event:{message}");
                _actionableEventRepository.AddActionableEvent(DateTime.UtcNow, stateInfo[ErrorCode].ToString(), logLevel, message, stateInfo[HelpLink].ToString());
            }
        }
    }
}
