﻿using System.Collections.Generic;
using ToeKnife.Providers.Texture;

namespace ToeKnife.BspEditor.Environment.Empty
{
    public class EmptyTextureCollection : TextureCollection
    {
        public EmptyTextureCollection(IEnumerable<TexturePackage> packages) : base(packages)
        {
        }

        public override IEnumerable<string> GetBrowsableTextures() => GetAllTextures();
        public override IEnumerable<string> GetDecalTextures() => new string[0];
        public override IEnumerable<string> GetSpriteTextures() => new string[0];
        public override bool IsNullTexture(string name) => false;
        public override float GetOpacity(string name) => 1;
    }
}
