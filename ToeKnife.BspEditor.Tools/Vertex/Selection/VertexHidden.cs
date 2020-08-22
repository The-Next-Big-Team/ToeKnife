using System.Runtime.Serialization;
using ToeKnife.BspEditor.Primitives;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Common.Transport;

namespace ToeKnife.BspEditor.Tools.Vertex.Selection
{
    public class VertexHidden : IMapObjectData, IRenderVisibility
    {
        public bool IsRenderHidden => true;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Not serialisable
        }

        public SerialisedObject ToSerialisedObject()
        {
            // Not serialisable
            return null;
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public IMapElement Clone()
        {
            return new VertexHidden();
        }

    }
}
