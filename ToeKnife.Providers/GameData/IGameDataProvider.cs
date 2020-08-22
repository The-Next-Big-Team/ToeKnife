using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToeKnife.Providers.GameData
{
    public interface IGameDataProvider
    {
        DataStructures.GameData.GameData GetGameDataFromFiles(IEnumerable<string> files);

        bool IsValidForFile(string filename);
    }
}
