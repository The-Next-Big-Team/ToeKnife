﻿using System;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ToeKnife.BspEditor.Documents;
using ToeKnife.BspEditor.Modification;
using ToeKnife.BspEditor.Modification.Operations.Tree;
using ToeKnife.BspEditor.Primitives.MapData;
using ToeKnife.BspEditor.Primitives.MapObjectData;
using ToeKnife.BspEditor.Primitives.MapObjects;
using ToeKnife.BspEditor.Rendering.Viewport;
using ToeKnife.BspEditor.Tools.Properties;
using ToeKnife.Common;
using ToeKnife.Common.Shell.Components;
using ToeKnife.Common.Shell.Hotkeys;
using ToeKnife.DataStructures.Geometric;
using ToeKnife.Rendering.Cameras;

namespace ToeKnife.BspEditor.Tools.Decal
{
    /// <summary>
    /// The decal tool creates a decal on any face that is clicked in the 3D viewport.
    /// The decal will be created with the current texture in the texture toolbar.
    /// </summary>
    //[Export(typeof(ITool))]
    //[OrderHint("L")]
    //[DefaultHotkey("Shift+D")]
    class DecalTool : BaseTool
    {
        public DecalTool()
        {
            Usage = ToolUsage.View3D;
        }

        public override Image GetIcon()
        {
            return Resources.Tool_Decal;
        }

        public override string GetName()
        {
            return "Decal Tool";
        }

        protected override void MouseDown(MapDocument document, MapViewport viewport, PerspectiveCamera camera, ViewportEvent e)
        {
            var vp = viewport;
            if (vp == null) return;

            // Get the ray that is cast from the clicked point along the viewport frustrum
            var (rs, re) = camera.CastRayFromScreen(new Vector3(e.X, e.Y, 0));
            var ray = new Line(rs, re);

            // Grab all the elements that intersect with the ray
            var hit = document.Map.Root.GetIntersectionsForVisibleObjects(ray).FirstOrDefault();

            if (hit == null) return; // Nothing was clicked

            CreateDecal(document, hit.Intersection);
        }

        private async Task CreateDecal(MapDocument document, Vector3 origin)
        {
            var gameData = await document.Environment.GetGameData();

            var gd = gameData?.Classes.FirstOrDefault(x => x.Name == "infodecal");
            if (gd == null) return;

            var texture = document.Map.Data.GetOne<ActiveTexture>()?.Name;
            if (String.IsNullOrWhiteSpace(texture)) return;

            var tc = await document.Environment.GetTextureCollection();
            if (tc == null) return;
            
            if (!tc.HasTexture(texture)) return;

            var decal = new Primitives.MapObjects.Entity(document.Map.NumberGenerator.Next("MapObject"))
            {
                Data =
                {
                    new EntityData
                    {
                        Name = gd.Name,
                        Properties = {{"texture", texture}}
                    },
                    new ObjectColor(Colour.GetRandomBrushColour()),
                    new Origin(origin)
                }
            };

            await MapDocumentOperation.Perform(document, new Attach(document.Map.Root.ID, decal));
        }
    }
}
