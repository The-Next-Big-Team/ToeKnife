using System.Runtime.Serialization;
using ToeKnife.BspEditor.Primitives.MapObjects;

namespace ToeKnife.BspEditor.Primitives.MapObjectData
{
    /// <summary>
    /// Base interface for generic map object metadata
    /// </summary>
    public interface IMapObjectData : ISerializable, IMapElement
    {

    }
}