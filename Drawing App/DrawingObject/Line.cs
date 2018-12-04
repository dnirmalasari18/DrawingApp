using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using Drawing_App.Interface;

namespace Drawing_App.DrawingObject
{
    class Line : IDrawingObject
    {
        Point a, b;
        private Pen pen;

        IState currentState;
        Graphics graph;

        public Point From { get { return this.a; } set { this.a = value; } }
        public Point To { get { return this.b; } set { this.b = value; } }

        public Graphics TargetGraphic { set { this.graph = value; } }

        public Line()
        {
            this.currentState = PrevState.GetInstance();
            this.pen = new Pen(Color.Black);
        }
        public void Draw()
        {
            this.currentState.Draw(this);
        }

        public void Select()
        {
            if (this.currentState.Next() != null)
                this.currentState = this.currentState.Next();
        }

        public void Deselect()
        {
            this.currentState = StaticState.GetInstance();
        }
        public IDrawingObject Intersect(Point pos)
        {
            int x = this.From.X, y = this.From.Y;
            if (this.From.X > this.To.X) x = this.To.X;
            if (this.From.Y > this.To.Y) y = this.To.Y;

            if (pos.X > x && pos.X < x + Math.Abs(this.From.X - this.To.X) && pos.Y > y && pos.Y < y + Math.Abs(this.From.Y - this.To.Y)) return this;
            return null;
        }
        public void Translate()
        {

        }


        

        public void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Dash;
            if (this.graph != null)
            {
                this.graph.SmoothingMode = SmoothingMode.AntiAlias;
                this.graph.DrawLine(pen, this.From, this.To);
            }
        }

        public void RenderOnStatic()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.graph != null)
            {
                this.graph.SmoothingMode = SmoothingMode.AntiAlias;
                this.graph.DrawLine(pen, this.From, this.To);
            }
        }

        public void RenderOnMoveState()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.graph != null)
            {
                this.graph.SmoothingMode = SmoothingMode.AntiAlias;
                this.graph.DrawLine(pen, this.From, this.To);
            }
        }
        
    }
}