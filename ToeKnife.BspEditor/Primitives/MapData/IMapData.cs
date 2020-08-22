using System.Runtime.Serialization;
using ToeKnife.BspEditor.Primitives.MapObjects;

namespace ToeKnife.BspEditor.Primitives.MapData
{
    /// <summary>
    /// Base interface for generic map metadata
    /// </summary>
    public interface IMapData : ISerializable, IMapElement
    {
        bool AffectsRendering { get; }
    }
}