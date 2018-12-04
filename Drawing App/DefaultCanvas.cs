using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Drawing_App.Interface;

namespace Drawing_App
{
    class DefaultCanvas : Control, ICanvas
    {
        List<IDrawingObject> ObjectToDraw;
        ITool Tool;
        public ITool ActiveTool { get { return this.Tool; } set { this.Tool = value; } }


        public DefaultCanvas()
        {
            this.ObjectToDraw = new List<IDrawingObject>();
            this.DoubleBuffered = true;
            this.Tool = null;
        }
        public void AddDrawingObject(IDrawingObject obj)
        {
            this.ObjectToDraw.Add(obj);
        }

        public void RemoveDrawingObject(IDrawingObject obj)
        {
            this.ObjectToDraw.Remove(obj);
        }

        public IDrawingObject SelectObjectAt(Point pos)
        {
            IDrawingObject selected = null;

            foreach (IDrawingObject obj in ObjectToDraw)
            {
                selected = obj.Intersect(pos);
                if (selected != null)
                {
                    selected.Select();
                    break;
                }
            }

            if (selected == null)
            {
                DeselectAllObject();
            }
            return selected;
        }

        public void DeselectAllObject()
        {
            foreach (IDrawingObject obj in this.ObjectToDraw)
                obj.Deselect();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (IDrawingObject obj in ObjectToDraw)
            {
                obj.TargetGraphic = e.Graphics;
                obj.Draw();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Tool != null)
            {
                this.Tool.OnMouseDown(this, e);
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.Tool != null)
            {
                this.Tool.OnMouseUp(this, e);
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.Tool != null)
            {
                this.Tool.OnMouseMove(this, e);
                this.Invalidate();
                this.Update();
            }
        }
    }
}