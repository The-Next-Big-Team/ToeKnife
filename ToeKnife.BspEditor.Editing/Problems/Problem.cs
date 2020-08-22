using System.Collections.Generic;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.BspEditor.Primitives.MapObjects;

namespace ToeKnife.BspEditor.Editing.Problems
{
    public class Problem
    {
        public string Text { get; set; }
        public List<IMapObject> Objects { get; set; }
        public List<IMapObjectData> ObjectData { get; set; }

        public Problem()
        {
            Objects = new List<IMapObject>();
            ObjectData = new List<IMapObjectData>();
        }

        public Problem Add(IMapObject o)
        {
            Objects.Add(o);
            return this;
        }

        public Problem Add(IEnumerable<IMapObject> objs)
        {
            Objects.AddRange(objs);
            return this;
        }

        public Problem Add(IMapObjectData o)
        {
            ObjectData.Add(o);
            return this;
        }

        public Problem Add(IEnumerable<IMapObjectData> objs)
        {
            ObjectData.AddRange(objs);
            return this;
        }
    }
}