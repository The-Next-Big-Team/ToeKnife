using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;

namespace ToeKnife.BspEditor.Providers.Processors
{
    public interface IBspSourceProcessor
    {
        string OrderHint { get; }
        Task AfterLoad(MapDocument document);
        Task BeforeSave(MapDocument document);
    }
}
