// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Extensions.Logging;
using Timer = System.Timers.Timer;

namespace Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics
{
    public class ActionableEventInMemoryRepository : IActionableEventRepository
    {
        private readonly ConcurrentDictionary<string, ActionableEvent> _events = new ConcurrentDictionary<string, ActionableEvent>();
        private readonly Timer _resetTimer;

        public ActionableEventInMemoryRepository()
        {
            _resetTimer = new Timer()
            {
                AutoReset = true,
                Interval = 600000,
                Enabled = true
            };

            _resetTimer.Elapsed += OnFlushLogs;
        }

        private void OnFlushLogs(object sender, ElapsedEventArgs e)
        {
            FlushLogs();
        }

        public void AddActionableEvent(DateTime timestamp, string errorCode, LogLevel level, string message, string helpLink)
        {
            var actionableEvent = new ActionableEvent()
            {
                ErrorCode = errorCode,
                HelpLink = helpLink,
                LastOccuredTimeStamp = timestamp,
                Message = message,
                Level = level
            };

            _events.AddOrUpdate(errorCode, actionableEvent, (e, a) =>
            {
                a.IncrementHitCount();
                a.LastOccuredTimeStamp = timestamp;
                return a;
            });
        }

        public IEnumerable<ActionableEvent> GetEvents()
        {
            return _events.Values;
        }

        public void FlushLogs()
        {
            _events.Clear();
        }
    }
}
