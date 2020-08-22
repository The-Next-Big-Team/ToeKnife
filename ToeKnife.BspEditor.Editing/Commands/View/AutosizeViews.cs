using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands.View
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:View:AutosizeViews")]
    [MenuItem("View", "", "SplitView", "B")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_AutosizeViews))]
    public class AutosizeViews : BaseCommand
    {
        public override string Name { get; set; } = "Autosize views";
        public override string Details { get; set; } = "Automatically resize the split views to be the same size.";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("BspEditor:SplitView:Autosize");
        }
    }
}