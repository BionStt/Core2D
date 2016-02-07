﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Xunit;

namespace Core2D.UnitTests
{
    public class RecordTests
    {
        [Fact]
        [Trait("Core2D", "Data")]
        public void Inherits_From_ObservableObject()
        {
            var target = new Record();
            Assert.True(target is ObservableObject);
        }

        [Fact]
        [Trait("Core2D", "Data")]
        public void Columns_Not_Null()
        {
            var target = new Record();
            Assert.NotNull(target.Columns);
        }

        [Fact]
        [Trait("Core2D", "Data")]
        public void Values_Not_Null()
        {
            var target = new Record();
            Assert.NotNull(target.Values);
        }
    }
}