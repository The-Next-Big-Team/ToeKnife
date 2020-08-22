using System.Collections.Generic;
using System.Numerics;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Rendering.Cameras;
using ToeKnife.Rendering.Overlay;
using ToeKnife.Rendering.Viewports;

namespace ToeKnife.BspEditor.Rendering.Overlay
{
    public interface IMapObject2DOverlay
    {
        void Render(IViewport viewport, ICollection<IMapObject> objects, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im);
    }
}