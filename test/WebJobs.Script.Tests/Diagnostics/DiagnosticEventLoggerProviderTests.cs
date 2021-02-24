// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Script.Diagnostics;
using Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Microsoft.Azure.WebJobs.Script.Tests.Diagnostics
{
    public class DiagnosticEventLoggerProviderTests
    {
        [Fact]
        public void IsActionableEvent_FiltersMessagesBasedonState()
        {
            using (var provider = new DiagnosticEventLoggerProvider(new DiagnosticEventInMemoryRepository()))
            {
                var logger = provider.CreateLogger("DiagnosticEvents");
                logger.LogDiagnosticEvent(LogLevel.Error, 123, "FN123", "Actionable event occured", "https://fwlink", null);
            }
        }
    }
}
