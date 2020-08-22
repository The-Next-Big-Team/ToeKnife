using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands.Pointfile
{
    [AutoTranslate]
    //[Export(typeof(ICommand))]
    //[MenuItem("Map", "", "Pointfile", "F")]
    [CommandID("BspEditor:Map:UnloadPointfile")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_UnloadPointfile))]
    public class UnloadPointfile : BaseCommand
    {
        public override string Name { get; set; } = "Unload pointfile...";
        public override string Details { get; set; } = "Clear the currently loaded pointfile";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var pf = document.Map.Data.GetOne<Pointfile>();
            if (pf == null) return;

            await MapDocumentOperation.Perform(document, new TrivialOperation(
                d => d.Map.Data.Remove(pf),
                c => c.Add(c.Document.Map.Root)
            ));
        }
    }
}