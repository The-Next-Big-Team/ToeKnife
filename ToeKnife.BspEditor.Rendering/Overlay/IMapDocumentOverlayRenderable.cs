using ToeKnife.BspEditor.Documents;
using ToeKnife.Rendering.Overlay;

namespace ToeKnife.BspEditor.Rendering.Overlay
{
    public interface IMapDocumentOverlayRenderable : IOverlayRenderable
    {
        void SetActiveDocument(MapDocument doc);
    }
}