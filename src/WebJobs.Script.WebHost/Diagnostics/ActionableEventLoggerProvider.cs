// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Script.WebHost.Diagnostics
{
    public class ActionableEventLoggerProvider : ILoggerProvider
    {
        private readonly IActionableEventRepository _actionableEventRepository;

        public ActionableEventLoggerProvider(IActionableEventRepository actionableEventRepository)
        {
            _actionableEventRepository = actionableEventRepository;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ActionableEventLogger(_actionableEventRepository);
        }

        public void Dispose()
        {
        }
    }
}
