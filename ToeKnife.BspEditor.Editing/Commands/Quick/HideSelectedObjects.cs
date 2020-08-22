using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations.Data;
using ToeKnife.BspEditor.Modification.Operations.Selection;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands.Quick
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("View", "", "Quick", "B")]
    [CommandID("BspEditor:View:QuickHideSelected")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_HideSelected))]
    [DefaultHotkey("H")]
    public class HideSelectedObjects : BaseCommand
    {
        public override string Name { get; set; } = "Quick hide selected";
        public override string Details { get; set; } = "Quick hide selected objects";

        protected override bool IsInContext(IContext context, MapDocument document)
        {
            return base.IsInContext(context, document) && !document.Selection.IsEmpty;
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Selection.ToList())
            {
                var ex = mo.Data.GetOne<QuickHidden>();
                if (ex != null) transaction.Add(new RemoveMapObjectData(mo.ID, ex));
                transaction.Add(new AddMapObjectData(mo.ID, new QuickHidden()));
            }

            transaction.Add(new Deselect(document.Selection));

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}
