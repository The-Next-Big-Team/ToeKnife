using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using ToeKnife.DataStructures.Geometric;
using ToeKnife.Providers.Model.d3d.Format;
using ToeKnife.Rendering.Engine;
using ToeKnife.Rendering.Interfaces;
using ToeKnife.Rendering.Pipelines;
using ToeKnife.Rendering.Primitives;
using ToeKnife.Rendering.Resources;
using ToeKnife.Rendering.Viewports;
using Veldrid;
using Buffer = ToeKnife.Rendering.Resources.Buffer;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace ToeKnife.Providers.Model.d3d
{
    public class D3dModel : IModel
    {
        public D3dFile Model { get; }
        private readonly Guid _guid;

        public D3dModel(D3dFile model)
        {
            Model = model;
            _guid = Guid.NewGuid();
        }

        public List<string> GetSequences()
        {
            var dingbat = new List<string>();
            dingbat.Add("studio");
            return dingbat;
        }

        public void CreateResources(EngineInterface engine, RenderContext context)
        {
            //
        }

        public void DestroyResources()
        {
            //
        }

        public void Dispose()
        {
            //
        }
    }
}
