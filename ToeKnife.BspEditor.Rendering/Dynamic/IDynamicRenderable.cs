using ToeKnife.BspEditor.Rendering.Resources;
using ToeKnife.Rendering.Resources;

namespace ToeKnife.BspEditor.Rendering.Dynamic
{
    public interface IDynamicRenderable
    {
        void Render(BufferBuilder builder, ResourceCollector resourceCollector);
    }
}