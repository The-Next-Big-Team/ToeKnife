using System.ComponentModel.Composition;
using System.Threading.Tasks;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:Exit")]
    [DefaultHotkey("Alt+F4")]
    [MenuItem("File", "", "Exit", "M")]
    public class Exit : ICommand
    {
        private readonly Forms.Shell _shell;

        public string Name { get; set; } = "Exit";
        public string Details { get; set; } = "Exit";

        [ImportingConstructor]
        internal Exit([Import] Forms.Shell shell)
        {
            _shell = shell;
        }

        public bool IsInContext(IContext context)
        {
            return true;
        }

        public Task Invoke(IContext context, CommandParameters parameters)
        {
            _shell.Close();
            return Task.CompletedTask;
        }
    }
}