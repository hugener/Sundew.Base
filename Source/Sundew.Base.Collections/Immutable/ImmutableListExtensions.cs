﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImmutableListExtensions.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Base.Collections.Immutable;

using System.Collections.Immutable;
using Sundew.Base.Primitives.Computation;

/// <summary>
/// Extension methods for <see cref="IImmutableList{T}"/>.
/// </summary>
public static class ImmutableListExtensions
{
    /// <summary>
    /// Converts the specified <see cref="IImmutableList{T}"/> to a <see cref="ValueList{TItem}"/>.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <param name="immutableList">The immutable list.</param>
    /// <returns>The value list.</returns>
    public static ValueList<TItem> ToValueList<TItem>(this IImmutableList<TItem> immutableList)
    {
        return new ValueList<TItem>(immutableList);
    }

    /// <summary>
    /// Tries to add the option item if it has any.
    /// </summary>
    /// <typeparam name="TList">The list type.</typeparam>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <param name="immutableList">The immutable list.</param>
    /// <param name="option">The option.</param>
    /// <returns>The resulting list.</returns>
    public static TList TryAdd<TList, TItem>(this TList immutableList, O<TItem> option)
        where TList : IImmutableList<TItem>
    {
        return option.HasValue ? (TList)immutableList.Add(option.Value) : immutableList;
    }

    /// <summary>
    /// Tries to add the result item if it has any.
    /// </summary>
    /// <typeparam name="TList">The list type.</typeparam>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <param name="immutableList">The immutable list.</param>
    /// <param name="result">The result.</param>
    /// <returns> The resulting list.</returns>
    public static TList TryAdd<TList, TItem>(this TList immutableList, R<TItem> result)
        where TList : IImmutableList<TItem>
    {
        return result.IsSuccess ? immutableList : (TList)immutableList.Add(result.Error);
    }

    /// <summary>
    /// Tries to add the result item if it has any.
    /// </summary>
    /// <typeparam name="TList">The list type.</typeparam>
    /// <typeparam name="TSuccess">The success type.</typeparam>
    /// <typeparam name="TError">The error type.</typeparam>
    /// <param name="immutableList">The immutable list.</param>
    /// <param name="result">The result.</param>
    /// <returns> The resulting list.</returns>
    public static TList TryAddSuccess<TList, TSuccess, TError>(this TList immutableList, R<TSuccess, TError> result)
        where TList : IImmutableList<TSuccess>
    {
        return result.IsSuccess ? (TList)immutableList.Add(result.Value) : immutableList;
    }

    /// <summary>
    /// Tries to add the result item if it has any.
    /// </summary>
    /// <typeparam name="TList">The list type.</typeparam>
    /// <typeparam name="TSuccess">The success type.</typeparam>
    /// <typeparam name="TError">The error type.</typeparam>
    /// <param name="immutableList">The immutable list.</param>
    /// <param name="result">The result.</param>
    /// <returns> The resulting list.</returns>
    public static TList TryAddError<TList, TSuccess, TError>(this TList immutableList, R<TSuccess, TError> result)
        where TList : IImmutableList<TError>
    {
        return result.HasError ? (TList)immutableList.Add(result.Error) : immutableList;
    }
}