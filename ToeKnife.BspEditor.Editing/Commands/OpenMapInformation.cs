using System.ComponentModel.Composition;
using System.Threading.Tasks;
using LogicAndTrick.Oy;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Map", "", "Properties", "B")]
    [CommandID("BspEditor:Map:MapInformation")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_ShowInformation))]
    public class OpenMapInformation : BaseCommand
    {
        public override string Name { get; set; } = "Map information";
        public override string Details { get; set; } = "Open the map information window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:MapInformation"));
        }
    }
}