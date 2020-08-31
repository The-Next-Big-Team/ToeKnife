using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToeKnife.FileSystem;
using ToeKnife.Providers.Model.d3d.Format;
using ToeKnife.Rendering.Interfaces;

namespace ToeKnife.Providers.Model.d3d
{
    [Export(typeof(IModelProvider))]
    class D3dModelProvider : IModelProvider
    {
        public bool CanLoadModel(IFile file)
        {
            return file.Exists && D3dFile.CanRead(file);
        }

        public async Task<IModel> LoadModel(IFile file)
        {
            return await Task.Factory.StartNew(() =>
            {
                var mdl = D3dFile.FromFile(file);
                //mdl.WriteFakePrecalculatedChromeCoordinates();
                return new D3dModel(mdl);
            });
        }

        public bool IsProvider(IModel model)
        {
            return true;// model is D3dModel;
        }

        public IModelRenderable CreateRenderable(IModel model)
        {
            return null;//new D3dModelRenderable((D3dModel)model);
        }
    }
}
