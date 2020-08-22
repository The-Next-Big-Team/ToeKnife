using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Primitives.MapObjects;

namespace ToeKnife.BspEditor.Editing.Problems
{
    public interface IProblemCheck
    {
        string Name { get; }
        string Details { get; }
        Uri Url { get; }
        bool CanFix { get; }

        Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter);
        Task Fix(MapDocument document, Problem problem);
    }
}
