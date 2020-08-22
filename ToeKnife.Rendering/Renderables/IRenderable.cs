using System;
using System.Collections.Generic;
using System.Numerics;
using ToeKnife.Rendering.Engine;
using ToeKnife.Rendering.Pipelines;
using ToeKnife.Rendering.Viewports;
using Veldrid;

namespace ToeKnife.Rendering.Renderables
{
    public interface IRenderable : IDisposable
    {
        IEnumerable<ILocation> GetLocationObjects(IPipeline pipeline, IViewport viewport);
        bool ShouldRender(IPipeline pipeline, IViewport viewport);
        void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl);
        void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl, ILocation locationObject);
    }

    public interface ILocation
    {
        Vector3 Location { get; }
    }
}
