using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations.Data;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands.Quick
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("View", "", "Quick", "F")]
    [CommandID("BspEditor:View:ShowHidden")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowHidden))]
    [DefaultHotkey("U")]
    public class ShowHiddenObjects : BaseCommand
    {
        public override string Name { get; set; } = "Show hidden objects";
        public override string Details { get; set; } = "Show objects hidden with quick hide";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.Find(x => x.Data.Get<QuickHidden>().Any()))
            {
                transaction.Add(new RemoveMapObjectData(mo.ID, mo.Data.GetOne<QuickHidden>()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}