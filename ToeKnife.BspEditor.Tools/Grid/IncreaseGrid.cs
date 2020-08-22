using System.ComponentModel.Composition;
using System.Linq;
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
    [CommandID("BspEditor:Grid:IncreaseSpacing")]
    [DefaultHotkey("]")]
    [MenuItem("Map", "", "Grid", "H")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_LargerGrid))]
    [AutoTranslate]
    public class IncreaseGrid : ICommand
    {
        public string Name { get; set; } = "Bigger Grid";
        public string Details { get; set; } = "Increase the grid size";

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out MapDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            if (context.TryGet("ActiveDocument", out MapDocument doc))
            {
                var gd = doc.Map.Data.Get<GridData>().FirstOrDefault();
                var grid = gd?.Grid;
                if (grid != null)
                {
                    var operation = new TrivialOperation(x => grid.Spacing++, x => x.Update(gd));
                    await MapDocumentOperation.Perform(doc, operation);
                }
            }
        }
    }
}