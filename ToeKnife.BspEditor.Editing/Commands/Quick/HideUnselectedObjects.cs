﻿using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Commands;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Editing.Properties;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations.Data;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Common.Shell.Commands;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.Common.Shell.Menu;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Editing.Commands.Quick
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("View", "", "Quick", "D")]
    [CommandID("BspEditor:View:QuickHideUnselected")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_HideUnselected))]
    [DefaultHotkey("Ctrl+H")]
    public class HideUnselectedObjects : BaseCommand
    {
        public override string Name { get; set; } = "Quick hide unselected";
        public override string Details { get; set; } = "Quick hide unselected objects";

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var transaction = new Transaction();

            foreach (var mo in document.Map.Root.FindAll().Except(document.Selection).Where(x => !(x is Root)).ToList())
            {
                var ex = mo.Data.GetOne<QuickHidden>();
                if (ex != null) transaction.Add(new RemoveMapObjectData(mo.ID, ex));
                transaction.Add(new AddMapObjectData(mo.ID, new QuickHidden()));
            }

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}