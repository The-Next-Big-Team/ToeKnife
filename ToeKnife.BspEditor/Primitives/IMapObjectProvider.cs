using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Common.Transport;

namespace ToeKnife.BspEditor.Primitives
{
    public interface IMapElementFormatter
    {
        bool IsSupported(IMapElement obj);
        SerialisedObject Serialise(IMapElement elem);

        bool IsSupported(SerialisedObject elem);
        IMapElement Deserialise(SerialisedObject obj);
    }
}
