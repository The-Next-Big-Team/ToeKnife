using System.Collections.Generic;

namespace ToeKnife.BspEditor.Rendering.Viewport
{
    public interface IViewportEventListenerFactory
    {
        IEnumerable<IViewportEventListener> Create(MapViewport viewport);
    }
}