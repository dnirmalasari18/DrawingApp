using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Drawing_App
{
    class Line : IDrawingObject
    {
        Point a, b;

        public Point From{ get { return this.a; } set { this.a = value; } }
        public Point To { get { return this.b; } set { this.b = value; } }

        public void SwapX() { int temp = a.X; a.X = b.X; b.X = temp; }
        public void SwapY() { int temp = a.Y; a.Y = b.Y; b.Y = temp; }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, a, b);
        }

        public IDrawingObject Collide(Point target)
        {
            IDrawingObject drawingObject = null;

            if (target.X >= a.X && target.X <= b.X && target.Y >= a.Y && target.Y <= b.Y)
                drawingObject = this;

            return drawingObject;
        }
        public void Move(Point target)
        {
            a.X += target.X;
            b.X += target.X;

            a.Y += target.Y;
            b.Y += target.Y;
        }

    }
}
