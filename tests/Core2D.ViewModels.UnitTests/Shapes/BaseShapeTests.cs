﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using Core2D.Interfaces;
using Core2D.Renderer;
using Xunit;

namespace Core2D.Shapes.UnitTests
{
    public class BaseShapeTests
    {
        private readonly IFactory _factory = new Factory();

        [Fact]
        [Trait("Core2D.Shapes", "Shapes")]
        public void Inherits_From_ObservableObject()
        {
            var target = new Class1();
            Assert.True(target is IObservableObject);
        }

        private class Class1 : BaseShape
        {
            public override Type TargetType => typeof(Class1);

            public override object Copy(IDictionary<object, object> shared)
            {
                throw new NotImplementedException();
            }

            public override void Draw(object dc, IShapeRenderer renderer, double dx, double dy, object db, object r)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<IPointShape> GetPoints()
            {
                throw new NotImplementedException();
            }

            public override void Move(ISet<IBaseShape> selected, double dx, double dy)
            {
                throw new NotImplementedException();
            }
        }
    }
}
