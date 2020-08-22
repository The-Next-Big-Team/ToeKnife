using System.Diagnostics;
using System.Windows.Forms;
using ToeKnife.BspEditor.Documents;

namespace ToeKnife.BspEditor.Editing.Components
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            VersionLabel.Text = FileVersionInfo.GetVersionInfo(typeof (MapDocument).Assembly.Location).FileVersion;
            GPLLink.Click += (s, e) => OpenSite("https://opensource.org/licenses/BSD-3-Clause");
        }

        private void OpenSite(string url)
        {
            Process.Start(url);
        }

    }
}
