using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using ToeKnife.BspEditor.Documents;
using ToeKnife.Common.Shell.Components;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Rendering.Components
{
    [Export(typeof(IStatusItem))]
    [AutoTranslate]
    [OrderHint("J")]
    public class ViewportZoomStatusItem : IStatusItem
    {
        public event EventHandler<string> TextChanged;

        public string ID => "ToeKnife.BspEditor.Rendering.Components.ViewportZoomStatusItem";
        public int Width => 100;
        public bool HasBorder => true;
        public string Text { get; set; } = "";

        public string Zoom { get; set; }
        
        public ViewportZoomStatusItem()
        {
            Oy.Subscribe<float>("MapDocument:ViewportZoomStatus:UpdateValue", UpdateValue);
        }

        private Task UpdateValue(float value)
        {
            var text = value <= 0 ? "" : $"{Zoom}: {value:#0.##}";
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
