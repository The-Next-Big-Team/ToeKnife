using System;
using System.Collections.Generic;
using ToeKnife.Rendering.Engine;
using ToeKnife.Rendering.Renderables;
using ToeKnife.Rendering.Viewports;
using Veldrid;

namespace ToeKnife.Rendering.Pipelines
{
    public interface IPipeline : IDisposable
    {
        PipelineType Type { get; }
        PipelineGroup Group { get; }
        float Order { get; }

        void Create(RenderContext context);
        void SetupFrame(RenderContext context, IViewport target);
        void Render(RenderContext context, IViewport target, CommandList cl, IEnumerable<IRenderable> renderables);
        void Render(RenderContext context, IViewport target, CommandList cl, IRenderable renderable, ILocation locationObject);
        void Bind(RenderContext context, CommandList cl, string binding);
    }
}
