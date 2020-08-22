using System.Collections.Generic;
using ToeKnife.BspEditor.Tools.Vertex.Selection;

namespace ToeKnife.BspEditor.Tools.Vertex.Errors
{
    public interface IVertexErrorCheck
    {
        IEnumerable<VertexError> GetErrors(VertexSolid solid);
    }
}
