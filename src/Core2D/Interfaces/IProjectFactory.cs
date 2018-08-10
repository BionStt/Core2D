﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Core2D.Containers.Interfaces;

namespace Core2D.Interfaces
{
    /// <summary>
    /// Defines project factory contract.
    /// </summary>
    public interface IProjectFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="IPageContainer"/> class.
        /// </summary>
        /// <param name="project">The new template owner project.</param>
        /// <param name="name">The new template name.</param>
        /// <returns>The new instance of the <see cref="IPageContainer"/>.</returns>
        IPageContainer GetTemplate(IProjectContainer project, string name);

        /// <summary>
        /// Creates a new instance of the <see cref="IPageContainer"/> class.
        /// </summary>
        /// <param name="project">The new page owner project.</param>
        /// <param name="name">The new page name.</param>
        /// <returns>The new instance of the <see cref="IPageContainer"/>.</returns>
        IPageContainer GetPage(IProjectContainer project, string name);

        /// <summary>
        /// Creates a new instance of the <see cref="IDocumentContainer"/> class.
        /// </summary>
        /// <param name="project">The new document owner project.</param>
        /// <param name="name">The new document name.</param>
        /// <returns>The new instance of the <see cref="IDocumentContainer"/>.</returns>
        IDocumentContainer GetDocument(IProjectContainer project, string name);

        /// <summary>
        /// Creates a new instance of the <see cref="IProjectContainer"/> class.
        /// </summary>
        /// <returns>The new instance of the <see cref="IProjectContainer"/>.</returns>
        IProjectContainer GetProject();
    }
}
