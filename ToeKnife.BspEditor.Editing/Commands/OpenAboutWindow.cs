using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Editing.Components;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Help", "", "About", "Z")]
    [CommandID("BspEditor:Help:About")]
    public class OpenAboutWindow : ICommand
    {
        public string Name { get; set; } = "About ToeKnife";
        public string Details { get; set; } = "View information about this application";

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            using (var vg = new AboutDialog())
            {
                vg.ShowDialog();
            }
        }
    }
}