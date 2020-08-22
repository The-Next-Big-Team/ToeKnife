using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Rendering.Resources;
using ToeKnife.Rendering.Resources;

namespace ToeKnife.BspEditor.Rendering.Dynamic
{
    public interface IMapObjectDynamicRenderable
    {
        void Render(MapDocument document, BufferBuilder builder, ResourceCollector resourceCollector);
    }
}