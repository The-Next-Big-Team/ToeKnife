using System.ComponentModel.Composition;
using System.Drawing;
using System.Numerics;
using ToeKnife.BspEditor.Documents;
using ToeKnife.Rendering.Cameras;
using ToeKnife.Rendering.Overlay;
using ToeKnife.Rendering.Viewports;

namespace ToeKnife.BspEditor.Rendering.Overlay
{
    [Export(typeof(IMapDocumentOverlayRenderable))]
    public class ViewportTextOverlay : IMapDocumentOverlayRenderable
    {
        public void SetActiveDocument(MapDocument doc)
        {
            //
        }

        public void Render(IViewport viewport, OrthographicCamera camera, Vector3 worldMin, Vector3 worldMax, I2DRenderer im)
        {
            var str = $"";
            switch (camera.ViewType)
            {
                case OrthographicCamera.OrthographicType.Front:
                    str = $"2-D Side";
                    break;
                case OrthographicCamera.OrthographicType.Side:
                    str = $"Gameplay View (Front)";
                    break;
                case OrthographicCamera.OrthographicType.Top:
                    str = $"2-D Top";
                    break;
            }

            var size = im.CalcTextSize(FontType.Normal, str);
            im.AddText(new Vector2(2, 2), Color.White, FontType.Normal, str);
            im.AddRectFilled(Vector2.Zero, size + new Vector2(4, 4), Color.FromArgb(128, Color.Pink));
        }

        public void Render(IViewport viewport, PerspectiveCamera camera, I2DRenderer im)
        {
            var str = $"3-D View";
            var size = im.CalcTextSize(FontType.Normal, str);
            im.AddText(new Vector2(2, 2), Color.White, FontType.Normal, str);
            im.AddRectFilled(Vector2.Zero, size + new Vector2(4, 4), Color.FromArgb(128, Color.Pink));
        }
    }
}
