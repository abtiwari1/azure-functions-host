// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics
{
    public class ActionableEvent
    {
        private int _hitCount = 0;

        public DateTime LastOccuredTimeStamp { get; set; }

        public string Message { get; set; }

        public string ErrorCode { get; set; }

        public string HelpLink { get; set; }

        public LogLevel Level { get; set; }

        public int HitCount => _hitCount;

        public void IncrementHitCount()
        {
            Interlocked.Increment(ref _hitCount);
        }
    }
}
