// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Script.Diagnostics;
using Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Microsoft.Azure.WebJobs.Script.Tests.Diagnostics
{
    public class ActionableEventLoggerProviderTests
    {
        [Fact]
        public void IsActionableEvent_FiltersMessagesBasedonState()
        {
            using (var provider = new ActionableEventLoggerProvider())
            {
                var logger = provider.CreateLogger("ActionableEvents");
                logger.LogActionableEvent(LogLevel.Error, 123, "Actionable event occured", "https://fwlink", null);
            }
        }
    }
}
