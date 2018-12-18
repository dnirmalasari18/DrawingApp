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
    class Circle : IDrawingObject
    {
        Point start, end;
        private Pen pen;
        public event EventHandler LocationChanged;
        IState currentState;
        Graphics graph;
        List<IDrawingObject> component;

        public Point From { get { return this.start; } set { this.start = value; } }
        public Point To { get { return this.end; } set { this.end = value; } }

        public Graphics TargetGraphic { set { this.graph = value; } }

        public Circle()
        {
            this.currentState = PrevState.GetInstance();
            this.pen = new Pen(Color.Black);
            this.component = new List<IDrawingObject>();
        }
        public void Draw()
        {
            this.currentState.Draw(this);
            this.currentState.Draw(this);
            foreach (IDrawingObject obj in this.component)
            {
                obj.TargetGraphic = this.graph;
                obj.Draw();
            }
        }

        public void Select()
        {
            if (this.currentState.Next() != null)
            {
                this.currentState = this.currentState.Next();
                foreach (IDrawingObject obj in this.component)
                {
                    obj.Select();
                }
            }
        }

        public void Deselect()
        {
            this.currentState = StaticState.GetInstance();
            foreach (IDrawingObject obj in this.component)
            {
                obj.Deselect();
            }
        }
        public List<IDrawingObject> GetComponent()
        {
            return this.component;
        }

        public void AddComponent(IDrawingObject obj)
        {
            this.component.Add(obj);
        }

        public void RemoveComponent(IDrawingObject obj)
        {
            this.component.Remove(obj);
        }
        public IDrawingObject Intersect(Point pos)
        {
            int x = this.From.X, y = this.From.Y;
            if (this.From.X > this.To.X) x = this.To.X;
            if (this.From.Y > this.To.Y) y = this.To.Y;

            if (pos.X > x && pos.X < x + Math.Abs(this.From.X - this.To.X) && pos.Y > y && pos.Y < y + Math.Abs(this.From.Y - this.To.Y)) return this;
            foreach (IDrawingObject obj in this.component)
            {
                IDrawingObject temp = obj.Intersect(pos);
                if (temp != null) return this;
            }
            return null;
        }
        public void Translate(Point pos)
        {
            this.start.X += pos.X;
            this.start.Y += pos.Y;
            this.end.X += pos.X;
            this.end.Y += pos.Y;
            foreach (IDrawingObject obj in this.component)
            {
                obj.Translate(pos);
            }
            OnLocationChanged();
        }

        

        public void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            int x = this.From.X, y = this.From.Y;
            if (this.From.X > this.To.X) x = this.To.X;
            if (this.From.Y > this.To.Y) y = this.To.Y;
            if (this.graph != null)
            {
                this.graph.SmoothingMode = SmoothingMode.AntiAlias;
                this.graph.DrawEllipse(pen, x, y, Math.Abs(this.From.X - this.To.X), Math.Abs(this.From.Y - this.To.Y));
            }
        }

        public void RenderOnStatic()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            int x = this.From.X, y = this.From.Y;
            if (this.From.X > this.To.X) x = this.To.X;
            if (this.From.Y > this.To.Y) y = this.To.Y;
            if (this.graph != null)
            {
                SolidBrush solidBrush = new SolidBrush(Color.White);
                GraphicsPath grapPath = new GraphicsPath();
                Rectangle rectangle = new Rectangle(x, y, Math.Abs(this.start.X - this.end.X), Math.Abs(this.start.Y - this.end.Y));
                grapPath.AddEllipse(rectangle);
                this.graph.FillPath(solidBrush, grapPath);
                this.graph.DrawPath(pen, grapPath);
            }

        }

        public void RenderOnMoveState()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            int x = this.From.X, y = this.From.Y;
            if (this.From.X > this.To.X) x = this.To.X;
            if (this.From.Y > this.To.Y) y = this.To.Y;
            if (this.graph != null)
            {
                SolidBrush solidBrush = new SolidBrush(Color.White);
                GraphicsPath grapPath = new GraphicsPath();
                Rectangle rectangle = new Rectangle(x, y, Math.Abs(this.start.X - this.end.X), Math.Abs(this.start.Y - this.end.Y));
                grapPath.AddEllipse(rectangle);
                this.graph.FillPath(solidBrush, grapPath);
                this.graph.DrawPath(pen, grapPath);
            }
        }

        void OnLocationChanged()
        {
            if (LocationChanged != null)
            {
                LocationChanged(this, EventArgs.Empty);
            }
        }

    }
}