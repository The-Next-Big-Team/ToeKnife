﻿using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.Common.Transport;

namespace ToeKnife.BspEditor.Primitives.MapObjectData
{
    public class VisgroupHidden : IMapObjectData, IObjectVisibility
    {
        public bool IsHidden { get; set; }

        public VisgroupHidden(bool isHidden)
        {
            IsHidden = isHidden;
        }

        public VisgroupHidden(SerialisedObject obj)
        {
            IsHidden = obj.Get("IsHidden", false);
        }

        [Export(typeof(IMapElementFormatter))]
        public class ActiveTextureFormatter : StandardMapElementFormatter<VisgroupHidden> { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsHidden", IsHidden);
        }

        public IMapElement Clone()
        {
            return new VisgroupHidden(IsHidden);
        }

        public IMapElement Copy(UniqueNumberGenerator numberGenerator)
        {
            return Clone();
        }

        public SerialisedObject ToSerialisedObject()
        {
            var so = new SerialisedObject("VisgroupHidden");
            so.Set("IsHidden", IsHidden);
            return so;
        }
    }
}