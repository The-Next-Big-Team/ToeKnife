using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToeKnife.Common.Shell.Hooks;
using ToeKnife.Common.Translations;
using ToeKnife.Editor.Properties;
using ToeKnife.Shell;

namespace ToeKnife.Editor
{
    [Export(typeof(IInitialiseHook))]
    [AutoTranslate]
    public class ShellSetup : IInitialiseHook
    {
        private readonly Form _shell;

        public string Title { get; set; }

        [ImportingConstructor]
        public ShellSetup([Import("Shell")] Form shell)
        {
            _shell = shell;
        }

        public Task OnInitialise()
        {
            _shell.InvokeLater(() =>
            {
                //_shell.Icon = Resources.ToeKnife;
                _shell.Text = Title;

                var prop = _shell.GetType().GetProperty("Title");
                if (prop != null)
                {
                    prop.SetValue(_shell, Title);
                }
            });

            return Task.CompletedTask;
        }
    }
}
