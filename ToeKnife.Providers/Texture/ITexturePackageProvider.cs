using System.Collections.Generic;
using System.Threading.Tasks;
using ToeKnife.FileSystem;

namespace ToeKnife.Providers.Texture
{
    public interface ITexturePackageProvider
    {
        Task<TexturePackage> GetTexturePackage(TexturePackageReference reference);

        Task<IEnumerable<TexturePackage>> GetTexturePackages(IEnumerable<TexturePackageReference> references);

        IEnumerable<TexturePackageReference> GetPackagesInFile(IFile file);
    }
}