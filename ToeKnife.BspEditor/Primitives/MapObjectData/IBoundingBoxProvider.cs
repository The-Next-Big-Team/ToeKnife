using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.DataStructures.Geometric;

namespace ToeKnife.BspEditor.Primitives.MapObjectData
{
    public interface IBoundingBoxProvider : IMapObjectData
    {
        Box GetBoundingBox(IMapObject obj);
    }
}
