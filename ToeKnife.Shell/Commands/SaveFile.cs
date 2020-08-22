using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicAndTrick.Oy;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Context;
using ToeKnife.Common.Shell.Documents;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;
using ToeKnife.Shell.Properties;
using ToeKnife.Shell.Registers;

namespace ToeKnife.Shell.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [CommandID("File:Save")]
    [DefaultHotkey("Ctrl+S")]
    [MenuItem("File", "", "File", "H")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_Save))]
    public class SaveFile : ICommand
    {
        private readonly Lazy<DocumentRegister> _documentRegister;

        public string Name { get; set; } = "Save";
        public string Details { get; set; } = "Save";

        [ImportingConstructor]
        public SaveFile(
            [Import] Lazy<DocumentRegister> documentRegister
        )
        {
            _documentRegister = documentRegister;
        }

        public bool IsInContext(IContext context)
        {
            return context.TryGet("ActiveDocument", out IDocument _);
        }

        public async Task Invoke(IContext context, CommandParameters parameters)
        {
            var doc = context.Get<IDocument>("ActiveDocument");
            if (doc != null)
            {
                var filename = doc.FileName;

                if (filename == null || !Directory.Exists(Path.GetDirectoryName(filename)))
                {
                    //var filter = _documentRegister.Value.GetSupportedFileExtensions(doc)
                    //    .Select(x => x.Description + "|" + String.Join(";", x.Extensions.Select(ex => "*" + ex)))
                    //    .ToList();

                    var filter = new List<String>();
                    //var filter2 = _loaders.Select(x => x.Value).Select(x => x.FileTypeDescription + "|" + String.Join(";", x.SupportedFileExtensions.SelectMany(e => e.Extensions).Select(e => "*" + e))).ToList();

                    filter.Add("Raft Map File|*.map");
                    filter.Add("All files|*.*");

                    using (var sfd = new SaveFileDialog {Filter = String.Join("|", filter)})
                    {
                        if (sfd.ShowDialog() != DialogResult.OK) return;
                        filename = sfd.FileName;
                    }
                }

                await _documentRegister.Value.SaveDocument(doc, filename);
            }
        }
    }
}