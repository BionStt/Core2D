﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Core2D.Containers;
using Core2D.Data;
using Core2D.Renderer;
using System.Windows;
using System.Windows.Media;

namespace Core2D.UI.Wpf.Views.Custom
{
    /// <summary>
    /// The custom layer control.
    /// </summary>
    public class LayerElement : FrameworkElement
    {
        /// <summary>
        /// Gets the <see cref="IContext"/> from <see cref="DependencyProperty"/> object.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyProperty"/> object.</param>
        /// <returns>The <see cref="IContext"/> value.</returns>
        public static IContext GetData(DependencyObject obj)
        {
            return (IContext)obj.GetValue(DataProperty);
        }

        /// <summary>
        /// Sets the <see cref="DependencyProperty"/> object value as <see cref="IContext"/>.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyProperty"/> object.</param>
        /// <param name="value">The <see cref="IContext"/> value.</param>
        public static void SetData(DependencyObject obj, IContext value)
        {
            obj.SetValue(DataProperty, value);
        }

        /// <summary>
        /// The attached <see cref="DependencyProperty"/> for <see cref="IContext"/> type.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.RegisterAttached(
                "Data",
                typeof(IContext),
                typeof(LayerElement),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.Inherits |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsArrange |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        /// <summary>
        /// Gets the <see cref="IShapeRenderer"/> from <see cref="DependencyProperty"/> object.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyProperty"/> object.</param>
        /// <returns>The <see cref="IShapeRenderer"/> value.</returns>
        public static IShapeRenderer GetRenderer(DependencyObject obj)
        {
            return (IShapeRenderer)obj.GetValue(RendererProperty);
        }

        /// <summary>
        /// Sets the <see cref="DependencyProperty"/> object value as <see cref="IShapeRenderer"/>.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyProperty"/> object.</param>
        /// <param name="value">The <see cref="IShapeRenderer"/> value.</param>
        public static void SetRenderer(DependencyObject obj, IShapeRenderer value)
        {
            obj.SetValue(RendererProperty, value);
        }

        /// <summary>
        /// The attached <see cref="DependencyProperty"/> for <see cref="IShapeRenderer"/> type.
        /// </summary>
        public static readonly DependencyProperty RendererProperty =
            DependencyProperty.RegisterAttached(
                "Renderer",
                typeof(IShapeRenderer),
                typeof(LayerElement),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.Inherits |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsArrange |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        /// <summary>
        /// Gets the <see cref="IDataFlow"/> from <see cref="DependencyProperty"/> object.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyProperty"/> object.</param>
        /// <returns>The <see cref="IDataFlow"/> value.</returns>
        public static IDataFlow GetDataFlow(DependencyObject obj)
        {
            return (IDataFlow)obj.GetValue(DataFlowProperty);
        }

        /// <summary>
        /// Sets the <see cref="DependencyProperty"/> object value as <see cref="IDataFlow"/>.
        /// </summary>
        /// <param name="obj">The <see cref="DependencyProperty"/> object.</param>
        /// <param name="value">The <see cref="IDataFlow"/> value.</param>
        public static void SetDataFlow(DependencyObject obj, IDataFlow value)
        {
            obj.SetValue(DataFlowProperty, value);
        }

        /// <summary>
        /// The attached <see cref="DependencyProperty"/> for <see cref="IDataFlow"/> type.
        /// </summary>
        public static readonly DependencyProperty DataFlowProperty =
            DependencyProperty.RegisterAttached(
                "DataFlow",
                typeof(IDataFlow),
                typeof(LayerElement),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.Inherits |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsArrange |
                    FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        private bool _isLoaded = false;
        private ILayerContainer _layer = default;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayerElement"/> class.
        /// </summary>
        public LayerElement()
        {
            Loaded +=
                (s, e) =>
                {
                    if (_isLoaded)
                        return;
                    else
                        _isLoaded = true;

                    Initialize();
                };

            Unloaded +=
                (s, e) =>
                {
                    if (!_isLoaded)
                        return;
                    else
                        _isLoaded = false;

                    DeInitialize();
                };

            DataContextChanged +=
                (s, e) =>
                {
                    if (!_isLoaded)
                        _isLoaded = true;

                    if (_layer != null)
                    {
                        var layer = DataContext as ILayerContainer;
                        if (layer == _layer)
                            return;
                    }

                    Initialize();
                };

            RenderOptions.SetBitmapScalingMode(
                this,
                BitmapScalingMode.HighQuality);
        }

        private void Invalidate(object sender, InvalidateLayerEventArgs e) => Dispatcher.Invoke(() => InvalidateVisual());

        private void Initialize()
        {
            if (_layer != null)
            {
                DeInitialize();
            }

            if (DataContext is ILayerContainer layer)
            {
                _layer = layer;
                _layer.InvalidateLayer += Invalidate;
            }
        }

        private void DeInitialize()
        {
            if (_layer != null)
            {
                _layer.InvalidateLayer -= Invalidate;
                _layer = default;
            }
        }

        /// <inheritdoc/>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Render(drawingContext);
        }

        private void Render(DrawingContext drawingContext)
        {
            if (DataContext is ILayerContainer layer && layer.IsVisible)
            {
                var renderer = LayerElement.GetRenderer(this);
                var data = LayerElement.GetData(this);
                var dataFlow = LayerElement.GetDataFlow(this);

                if (data != null && dataFlow != null)
                {
                    var db = data.Properties;
                    var record = data.Record;

                    dataFlow.Bind(layer, db, record);
                }

                if (renderer != null)
                {
                    renderer.Draw(drawingContext, layer, 0.0, 0.0);
                }
            }
        }
    }
}
