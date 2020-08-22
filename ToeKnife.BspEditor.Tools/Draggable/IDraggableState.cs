using System.Collections.Generic;

namespace ToeKnife.BspEditor.Tools.Draggable
{
    public interface IDraggableState : IDraggable
    {
        IEnumerable<IDraggable> GetDraggables();
    }
}