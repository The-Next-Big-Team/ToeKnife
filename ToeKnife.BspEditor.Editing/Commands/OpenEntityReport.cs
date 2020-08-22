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
    [MenuItem("Map", "", "Properties", "F")]
    [CommandID("BspEditor:Map:EntityReport")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_EntityReport))]
    public class OpenEntityReport : BaseCommand
    {
        public override string Name { get; set; } = "Entity report";
        public override string Details { get; set; } = "Open the entity report window";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            await Oy.Publish("Context:Add", new ContextInfo("BspEditor:EntityReport"));
        }
    }
}