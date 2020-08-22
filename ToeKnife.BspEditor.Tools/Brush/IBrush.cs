using System.Collections.Generic;
using ToeKnife.BspEditor.Primitives;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.BspEditor.Tools.Brush.Brushes.Controls;
using ToeKnife.DataStructures.Geometric;

namespace ToeKnife.BspEditor.Tools.Brush
{
    public interface IBrush
    {
        string Name { get; }
        bool CanRound { get; }
        IEnumerable<BrushControl> GetControls();
        IEnumerable<IMapObject> Create(UniqueNumberGenerator idGenerator, Box box, string texture, int roundDecimals);
    }
}
