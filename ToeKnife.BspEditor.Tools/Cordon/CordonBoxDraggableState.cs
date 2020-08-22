using System.Numerics;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Primitives.MapData;
using ToeKnife.BspEditor.Rendering.Viewport;
using ToeKnife.BspEditor.Tools.Draggable;
using ToeKnife.Rendering.Cameras;

namespace ToeKnife.BspEditor.Tools.Cordon
{
    public class CordonBoxDraggableState : BoxDraggableState
    {
        public CordonBoxDraggableState(BaseDraggableTool tool) : base(tool)
        {
        }

        public void Update()
        {
            var document = Tool.GetDocument();
            if (document == null)
            {
                State.Action = BoxAction.Idle;
            }
            else
            {
                var cordon = document.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds {Enabled = false};
                State.Start = cordon.Box.Start;
                State.End = cordon.Box.End;
                State.Action = BoxAction.Drawn;
            }
        }

        public override void Click(MapDocument document, MapViewport viewport, OrthographicCamera camera,
            ViewportEvent e, Vector3 position)
        {
            //
        }

        public override bool CanDrag(MapDocument document, MapViewport viewport, OrthographicCamera camera,
            ViewportEvent e, Vector3 position)
        {
            return false;
        }
    }
}
