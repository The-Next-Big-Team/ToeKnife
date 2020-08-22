using System.Numerics;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Rendering.Viewport;
using ToeKnife.BspEditor.Tools.Draggable;
using ToeKnife.Rendering.Cameras;

namespace ToeKnife.BspEditor.Tools.Selection.TransformationHandles
{
    public interface ITransformationHandle : IDraggable
    {
        string Name { get; }
        Matrix4x4? GetTransformationMatrix(MapViewport viewport, OrthographicCamera camera, BoxState state, MapDocument doc);
        TextureTransformationType GetTextureTransformationType(MapDocument doc);
    }
}
