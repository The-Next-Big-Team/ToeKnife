using System.IO;
using System.Windows.Forms;
using ToeKnife.BspEditor.Tools.Properties;

namespace ToeKnife.BspEditor.Tools
{
    public static class ToolCursors
    {
        public static Cursor RotateCursor { get; }

        static ToolCursors()
        {
            RotateCursor = new Cursor(new MemoryStream(Resources.Cursor_Rotate));
        }
    }
}
