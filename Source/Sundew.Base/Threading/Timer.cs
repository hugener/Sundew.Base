﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Timer.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Base.Threading
{
    /// <summary>
    /// Implementation of a stateless timer.
    /// </summary>
    /// <seealso cref="Sundew.Base.Threading.TimerBase" />
    /// <seealso cref="Sundew.Base.Threading.ITimer" />
    public sealed class Timer : TimerBase, ITimer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Timer" /> class.
        /// </summary>
        public Timer()
            : base(null)
        {
        }

        /// <summary>
        /// Occurs when the timer ticks.
        /// </summary>
        public event TickEventHandler? Tick;

        /// <summary>
        /// Occurs when the timer ticks.
        /// </summary>
        /// <param name="state">The state.</param>
        protected override void OnTick(object state)
        {
            this.Tick?.Invoke(this);
        }
    }
}