using System.ComponentModel.Composition;
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
    [CommandID("BspEditor:Edit:SelectNone")]
    [DefaultHotkey("Shift+Q")]
    [MenuItem("Edit", "", "Selection", "D")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_SelectNone))]
    public class SelectNone : BaseCommand
    {
        public override string Name { get; set; } = "Select None";
        public override string Details { get; set; } = "Clear selection";

        protected override Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var op = new Deselect(document.Map.Root.FindAll());
            return MapDocumentOperation.Perform(document, op);
        }
    }
}