using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Drawing_App
{
    class DefaultCanvas : Control, ICanvas
    {
        public static int DrawMode = 0;
        public static int MoveMode = 1;
        int mode;
        ITool Tool;
        Point LastPoint, CurrentPoint;
        IDrawingObject ObjectToMove;
        public ITool GetTool { get { return this.Tool; } set { this.Tool = value; } }
        public ICanvas GetCanvas() { return this; }
        public Control GetControl() { return this; }

        List<IDrawingObject> ObjectToDraw = new List<IDrawingObject>();
        public List<IDrawingObject> GetDrawingObject() { return this.ObjectToDraw; }

        public void SetMode(int X) { this.mode = X; }
        public void AddDrawingObject(IDrawingObject DrawObject)
        {
            ObjectToDraw.Add(DrawObject);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            foreach (IDrawingObject i in ObjectToDraw)
                i.Draw(g, Pens.Black);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.LastPoint = e.Location;
            if (Tool != null && mode == DefaultCanvas.DrawMode)
            {
                Tool.OnMouseDown(e.Location);
            }
            else if (Tool != null && mode == DefaultCanvas.MoveMode)
            {
                foreach (IDrawingObject currentObject in ObjectToDraw)
                {
                    IDrawingObject selected = currentObject.Collide(e.Location);

                    if (selected != null)
                    {
                        this.ObjectToMove = selected;
                        break;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.LastPoint = e.Location;
            if (Tool != null && mode == DefaultCanvas.DrawMode)
            {
                Tool.OnMouseUp(e.Location);
            }
            else if (this.ObjectToMove != null && Tool != null && mode == DefaultCanvas.MoveMode)
            {
                this.ObjectToMove.Move(CurrentPoint);
                this.ObjectToMove = null;
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.ObjectToMove != null && Tool != null && mode == DefaultCanvas.MoveMode)
            {
                int tempX = e.Location.X - LastPoint.X;
                int tempY = e.Location.Y - LastPoint.Y;

                this.CurrentPoint = new Point(tempX, tempY);
            }
        }

    }
}
