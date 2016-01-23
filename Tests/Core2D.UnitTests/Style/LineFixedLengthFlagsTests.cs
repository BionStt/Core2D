﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Xunit;

namespace Core2D.UnitTests
{
    public class LineFixedLengthFlagsTests
    {
        [Fact]
        public void Flags_Attribute_Not_Null()
        {
            Assert.NotNull(Attribute.GetCustomAttribute(typeof(LineFixedLengthFlags), typeof(FlagsAttribute)));
        }
    }
}
