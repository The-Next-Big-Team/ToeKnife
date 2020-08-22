using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations.Data;
using ToeKnife.BspEditor.Primitives.MapData;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Tools.Texture
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:ApplyActiveTexture")]
    [DefaultHotkey("Shift+T")]
    public class ApplyActiveTexture : ICommand
    {
        public string Name { get; set; } = "Apply active texture";
        public string Details { get; set; } = "Apply active texture to selected objects";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var md = context.Get<MapDocument>("ActiveDocument");
            if (md == null || md.Selection.IsEmpty) return;

            var at = md.Map.Data.GetOne<ActiveTexture>();
            if (String.IsNullOrWhiteSpace(at?.Name)) return;

            var edit = new Transaction();

            foreach (var solid in md.Selection.OfType<Solid>())
            {
                foreach (var face in solid.Faces)
                {
                    var clone = (Face) face.Clone();
                    clone.Texture.Name = at.Name;

                    edit.Add(new RemoveMapObjectData(solid.ID, face));
                    edit.Add(new AddMapObjectData(solid.ID, clone));
                }
            }

            if (!edit.IsEmpty) await MapDocumentOperation.Perform(md, edit);
        }
    }
}
