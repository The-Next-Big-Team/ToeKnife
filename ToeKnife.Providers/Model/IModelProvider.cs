using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToeKnife.FileSystem;
using ToeKnife.Rendering.Interfaces;

namespace ToeKnife.Providers.Model
{
    public interface IModelProvider
    {
        bool CanLoadModel(IFile file);
        Task<IModel> LoadModel(IFile file);

        bool IsProvider(IModel model);
        IModelRenderable CreateRenderable(IModel model);
    }
}
