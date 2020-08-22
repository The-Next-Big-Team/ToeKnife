using System;
using System.Windows.Forms;
using ToeKnife.Common.Translations;

namespace ToeKnife.BspEditor.Environment
{
    public interface IEnvironmentEditor : IManualTranslate
    {
        event EventHandler EnvironmentChanged;
        Control Control { get; }
        IEnvironment Environment { get; set; }
    }
}