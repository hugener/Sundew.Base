﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BufferHelper.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Base.Memory.Internal;

using Sundew.Base.Numeric;

internal static class BufferHelper
{
    public static readonly Interval<int> StartIndexInterval = Interval.From(10, 128);
}