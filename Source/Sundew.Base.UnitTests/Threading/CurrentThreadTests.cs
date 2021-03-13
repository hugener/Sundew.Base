﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentThreadTests.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Base.UnitTests.Threading
{
    using System.Diagnostics;
    using System.Threading;
    using FluentAssertions;
    using Sundew.Base.Threading;
    using Xunit;

    public class CurrentThreadTests
    {
        [Fact]
        public void Sleep_When_Cancelled_Then_ElapsedTimeShouldBeWithInRage()
        {
            var testee = new CurrentThread();
            var stopwatch = Stopwatch.StartNew();
            using var cancellationTokenSource = new CancellationTokenSource(20);

            testee.Sleep(60, cancellationTokenSource.Token);

            stopwatch.Stop();
            stopwatch.ElapsedMilliseconds.Should().BeInRange(19, 60);
        }

        [Fact]
        public void Sleep_When_NotCancelled_Then_ElapsedTimeShouldBeWithInRange()
        {
            var testee = new CurrentThread();
            var stopwatch = Stopwatch.StartNew();

            testee.Sleep(10, CancellationToken.None);

            stopwatch.Stop();
            stopwatch.ElapsedMilliseconds.Should().BeInRange(9, 15);
        }

        [Fact]
        public void Sleep_Then_ElapsedTimeShouldBeWithInRange()
        {
            var testee = new CurrentThread();
            var stopwatch = Stopwatch.StartNew();

            testee.Sleep(10);

            stopwatch.Stop();
            stopwatch.ElapsedMilliseconds.Should().BeInRange(9, 15);
        }
    }
}