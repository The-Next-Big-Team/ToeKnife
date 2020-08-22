using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations.Selection;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.BspEditor.Properties;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Commands.Modification
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:SelectAll")]
    [DefaultHotkey("Ctrl+A")]
    [MenuItem("Edit", "", "Selection", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectAll))]
    public class SelectAll : BaseCommand
    {
        public override string Name { get; set; } = "Select All";
        public override string Details { get; set; } = "Select all objects";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Select(document.Map.Root.FindAll().Where(x => x.Hierarchy.Parent != null));
            return MapDocumentOperation.Perform(document, op);
        }
    }
}
