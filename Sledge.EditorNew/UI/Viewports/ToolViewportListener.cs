﻿using OpenTK.Input;
using Sledge.Common.Mediator;
using Sledge.EditorNew.Tools;
using Sledge.Gui.Structures;

namespace Sledge.EditorNew.UI.Viewports
{
    public class ToolViewportListener : IViewportEventListener
    {
        public IMapViewport Viewport { get; set; }

        public ToolViewportListener(IMapViewport viewport)
        {
            Viewport = viewport;
        }

        private bool ShouldRelayEvent(BaseTool tool)
        {
            if (tool == null || !Viewport.IsUnlocked(this)) return false;
            var usage = tool.Usage;
            return usage == BaseTool.ToolUsage.Both
                   || (usage == BaseTool.ToolUsage.View2D && Viewport.Is2D)
                   || (usage == BaseTool.ToolUsage.View3D && Viewport.Is3D);
        }

        public void KeyUp(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.KeyUp(Viewport, e);
        }

        public void KeyDown(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.KeyDown(Viewport, e);
        }

        public void KeyPress(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.KeyPress(Viewport, e);
        }

        public void MouseMove(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseMove(Viewport, e);
        }

        public void MouseWheel(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseWheel(Viewport, e);
        }

        public void MouseUp(ViewportEvent e)
        {
            if (e.Button == MouseButton.Right && Viewport.Is2D) Mediator.Publish(EditorMediator.ViewportRightClick, new object[] { Viewport, e });
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseUp(Viewport, e);
        }

        public void MouseDown(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseDown(Viewport, e);
        }

        public void MouseClick(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseClick(Viewport, e);
        }

        public void MouseDoubleClick(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseDoubleClick(Viewport, e);
        }

        public void DragStart(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.DragStart(Viewport, e);
        }

        public void DragMove(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.DragMove(Viewport, e);
        }

        public void DragEnd(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.DragEnd(Viewport, e);
        }

        public void MouseEnter(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseEnter(Viewport, e);
        }

        public void MouseLeave(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.MouseLeave(Viewport, e);
        }

        public void ZoomChanged(ViewportEvent e)
        {
            // 
        }

        public void PositionChanged(ViewportEvent e)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.PositionChanged(Viewport, e);
        }

        public void UpdateFrame(Frame frame)
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.UpdateFrame(Viewport, frame);
        }

        public void PreRender()
        {
            if (!ShouldRelayEvent(ToolManager.ActiveTool)) return;
            ToolManager.ActiveTool.PreRender(Viewport);
        }

        public void Render3D()
        {

        }

        public void Render2D()
        {

        }

        public void PostRender()
        {

        }
    }
}