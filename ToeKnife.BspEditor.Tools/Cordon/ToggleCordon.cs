using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations;
using ToeKnife.BspEditor.Primitives.MapData;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.BspEditor.Tools.Properties;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Tools.Cordon
{
    //[Export(typeof(ICommand))]
    [CommandID("BspEditor:Cordon:ToggleCordon")]
    //[MenuItem("Tools", "", "Cordon", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Cordon))]
    [AutoTranslate]
    public class ToggleCordon : ICommand
    {
        public string Name { get; set; } = "Cordon Bounds";
        public string Details { get; set; } = "Toggle cordon bounds";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var cordon = doc.Map.Data.GetOne<CordonBounds>() ?? new CordonBounds {Enabled = false};
                cordon.Enabled = !cordon.Enabled;
                await MapDocumentOperation.Perform(doc, new TrivialOperation(x => x.Map.Data.Replace(cordon), x => x.Update(cordon).UpdateRange(doc.Map.Root.FindAll())));
            }
        }
    }
}