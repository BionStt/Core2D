﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Portable.Xaml.Markup;

namespace Core2D
{
    /// <summary>
    /// Observable <see cref="XGroup"/> collection.
    /// </summary>
    [ContentProperty(nameof(Children))]
    [RuntimeNameProperty(nameof(Name))]
    public class Groups : ObservableResource
    {
        /// <summary>
        /// Gets or sets container name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets children collection.
        /// </summary>
        public ICollection<XGroup> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Groups"/> class.
        /// </summary>
        public Groups()
        {
            Children = new Collection<XGroup>();
        }
    }
}