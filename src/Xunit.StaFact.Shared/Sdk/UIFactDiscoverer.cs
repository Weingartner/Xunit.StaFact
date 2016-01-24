﻿// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE.txt file in the project root for full license information.

namespace Xunit.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;

    /// <summary>
    /// The discovery class for the <see cref="UIFactAttribute"/>.
    /// </summary>
    public class UIFactDiscoverer : IXunitTestCaseDiscoverer
    {
        private readonly FactDiscoverer factDiscoverer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIFactDiscoverer"/> class.
        /// </summary>
        /// <param name="diagnosticMessageSink">The diagnostic message sink.</param>
        public UIFactDiscoverer(IMessageSink diagnosticMessageSink)
        {
            this.factDiscoverer = new FactDiscoverer(diagnosticMessageSink);
        }

        /// <inheritdoc/>
        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            return this.factDiscoverer.Discover(discoveryOptions, testMethod, factAttribute)
                                 .Select(testCase => new UITestCase(testCase));
        }
    }
}
