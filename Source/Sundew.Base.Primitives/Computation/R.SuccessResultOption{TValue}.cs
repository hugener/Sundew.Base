﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="R.SuccessResultOption{TValue}.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Base.Primitives.Computation;

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

/// <summary>
/// Factory class for creating results.
/// </summary>
public partial class R
{
    /// <summary>
    /// A successful result.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public readonly struct SuccessResultOption<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResultOption{TValue}"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        internal SuccessResultOption(TValue value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public TValue Value { get; }

        /// <summary>
        /// Always returns false.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>A value indicating whether the result was successful.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(SuccessResultOption<TValue> result)
        {
            return true;
        }

        /// <summary>
        /// Gets the result's value property.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>A value indicating whether the result was successful.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TValue(SuccessResultOption<TValue> result)
        {
            return result.Value;
        }

        /// <summary>Performs an implicit conversion from <see cref="ValueTask{SuccessResult}"/> to <see cref="SuccessResult{TValue}"/>.</summary>
        /// <param name="result">The result.</param>
        /// <returns>The result of the conversion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ValueTask<SuccessResultOption<TValue?>>(SuccessResultOption<TValue?> result)
        {
            return result.ToValueTask();
        }

        /// <summary>Performs an implicit conversion from <see cref="ValueTask{SuccessResult}"/> to <see cref="SuccessResult{TValue}"/>.</summary>
        /// <param name="result">The result.</param>
        /// <returns>The result of the conversion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SuccessResultOption<TValue?>(SuccessResult result)
        {
            return new SuccessResultOption<TValue?>(default(TValue?));
        }

        /// <summary>
        /// Converts this instance to a value task.
        /// </summary>
        /// <returns>The value task.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueTask<SuccessResultOption<TValue?>> ToValueTask()
        {
            return new ValueTask<SuccessResultOption<TValue?>>(this);
        }

        /// <summary>
        /// Creates a result based on the specified values.
        /// </summary>
        /// <typeparam name="TNewValue">The type of the new value.</typeparam>
        /// <param name="valueFunc">The value function.</param>
        /// <returns>
        /// A new <see cref="R" />.
        /// </returns>
        public SuccessResultOption<TNewValue?> To<TNewValue>(Func<TValue?, TNewValue?> valueFunc)
        {
            return new SuccessResultOption<TNewValue?>(valueFunc(this.Value));
        }

        /// <summary>
        /// Creates a result based on the specified values.
        /// </summary>
        /// <typeparam name="TNewValue">The type of the new value.</typeparam>
        /// <param name="valueFunc">The value function.</param>
        /// <returns>
        /// A new <see cref="R" />.
        /// </returns>
        public ValueTask<SuccessResultOption<TNewValue?>> ToAsync<TNewValue>(Func<TValue?, TNewValue?> valueFunc)
        {
            return new SuccessResultOption<TNewValue?>(valueFunc(this.Value)).ToValueTask();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Success: {this.Value}";
        }
    }
}