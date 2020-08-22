using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations;
using ToeKnife.BspEditor.Primitives.MapData;
using ToeKnife.BspEditor.Tools.Properties;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Tools.Grid
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Grid:ToggleSnapToGrid")]
    [DefaultHotkey("Shift+W")]
    [MenuItem("Map", "", "Grid", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SnapToGrid))]
    [AutoTranslate]
    public class ToggleSnapToGrid : ICommand
    {
        public string Name { get; set; } = "Snap to Grid";
        public string Details { get; set; } = "Toggle grid snapping";
        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var activeGrid = doc.Map.Data.GetOne<GridData>();
                if (activeGrid != null)
                {
                    var operation = new TrivialOperation(x => activeGrid.SnapToGrid = !activeGrid.SnapToGrid, x => x.Update(activeGrid));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}