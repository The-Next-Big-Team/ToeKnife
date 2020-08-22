using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.BspEditor.Modification;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.History
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Edit:Undo")]
    [DefaultHotkey("Ctrl+Z")]
    [MenuItem("Edit", "", "History", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Undo))]
    public class UndoCommand : BaseCommand
    {
        public override string Name { get; set; } = "Undo";
        public override string Details { get; set; } = "Undo the last operation";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var stack = document.Map.Data.GetOne<HistoryStack>();
            if (stack == null) return;
            if (stack.CanUndo()) await MapDocumentOperation.Reverse(document, stack.UndoOperation());
        }
    }
}