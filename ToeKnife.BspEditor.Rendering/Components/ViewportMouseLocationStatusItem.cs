using System;
using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using Newtonsoft.Json.Schema;
using ToeKnife.BspEditor.Documents;
using ToeKnife.Common.Shell.Components;
using ToeKnife.Common.Shell.Context;

namespace ToeKnife.BspEditor.Rendering.Components
{
    [Export(typeof(IStatusItem))]
    [OrderHint("F")]
    public class ViewportMouseLocationStatusItem : IStatusItem
    {
        public event EventHandler<string> TextChanged;

        public string ID => "ToeKnife.BspEditor.Rendering.Components.ViewportMouseLocationStatusItem";
        public int Width => 300;
        public bool HasBorder => true;
        public string Text { get; set; } = "";
        
        public ViewportMouseLocationStatusItem()
        {
            Oy.Subscribe<Vector3?>("MapDocument:ViewportMouseLocationStatus:UpdateValue", UpdateValue);
        }

        private Task UpdateValue(Vector3? value)
        {
            var text = "";
            if (value.HasValue)
            {
                var v = value.Value;
                //text = $"{v.X:#0} {v.Y:#0} {v.Z:#0}";
                var x = $"{(v.X + 4096):#0}";
                var y = $"{(v.Y):#0}";
                var z = $"{(v.Z - 4096)*-1:#0}";
                text = "X: " + x + ", Y: " + z + ", Z: " + y;
            }

            Text = text;
            TextChanged?.Invoke(this, Text);
            return Task.CompletedTask;
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }
    }
}