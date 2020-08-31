using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using ToeKnife.DataStructures.Geometric;
using ToeKnife.Rendering.Cameras;
using ToeKnife.Rendering.Engine;
using ToeKnife.Rendering.Interfaces;
using ToeKnife.Rendering.Pipelines;
using ToeKnife.Rendering.Renderables;
using ToeKnife.Rendering.Viewports;
using Veldrid;

namespace ToeKnife.Providers.Model.d3d
{
    public class D3dModelRenderable : IModelRenderable
    {
        private readonly D3dModel _model;
        public IModel Model => _model;

        private DeviceBuffer _transformsBuffer;
        private ResourceSet _transformsResourceSet;
        private Matrix4x4[] _transforms;

        private DeviceBuffer _frozenTransformsBuffer;
        private ResourceSet _frozenTransformsResourceSet;

        private int _currentFrame;
        private long _lastFrameMillis;
        private float _interframePercent;

        public Vector3 Origin { get; set; }
        public Vector3 Angles { get; set; }

        private int _lastSequence = -1;
        public int Sequence { get; set; }

        public D3dModelRenderable(D3dModel model)
        {
            _model = model;

        }

        public Matrix4x4 GetModelTransformation()
        {
            return Matrix4x4.CreateFromYawPitchRoll(Angles.X, Angles.Z, Angles.Y) * Matrix4x4.CreateTranslation(Origin);
        }

        public (Vector3, Vector3) GetBoundingBox()
        {
            Vector3 wah = new Vector3(0, 0, 0);
            return (wah, wah);
        }

        public void Update(long milliseconds)
        {
            //
        }

        public void CreateResources(EngineInterface engine, RenderContext context)
        {
            //
        }

        public IEnumerable<ILocation> GetLocationObjects(IPipeline pipeline, IViewport viewport)
        {
            yield break;
        }

        public bool ShouldRender(IPipeline pipeline, IViewport viewport)
        {
            return true;
        }

        public void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl)
        {
            //
        }

        public void Render(RenderContext context, IPipeline pipeline, IViewport viewport, CommandList cl, ILocation locationObject)
        {
            //
        }

        public void DestroyResources()
        {
            _transformsResourceSet?.Dispose();
            _transformsBuffer?.Dispose();
            _frozenTransformsResourceSet?.Dispose();
            _frozenTransformsBuffer?.Dispose();

            _transformsResourceSet = null;
            _transformsBuffer = null;
            _frozenTransformsResourceSet = null;
            _frozenTransformsBuffer = null;
        }

        public void Dispose()
        {
            //
        }
    }
}