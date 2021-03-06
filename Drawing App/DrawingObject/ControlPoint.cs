﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using Drawing_App.Interface;
namespace Drawing_App.DrawingObject
{
    class ControlPoint:Square
    {
        Point start, end;
        private Pen pen;
        IState currentState;
        Graphics graph;
        //List<IDrawingObject> component;
        public Point From { get { return this.start; } set { this.start = value; } }
        public Point To { get { return this.end; } set { this.end = value; } }

        public Graphics TargetGraphic { set { this.graph = value; } }

        public ControlPoint()
        {
            this.currentState = MoveState.GetInstance();
            this.pen = new Pen(Color.Black);
        }

        public ControlPoint(int x, int y)
        {
            this.start.X = x - 5;
            this.start.Y = y - 5;
            this.end.X = x + 5;
            this.end.Y = y + 5;
            this.currentState = MoveState.GetInstance();
            this.pen = new Pen(Color.Black);
        }

        public void Draw()
        {
            this.currentState.Draw(this);
        }

        public void Select()
        {

        }

        public void Deselect()
        {

        }

        public IDrawingObject Intersect(Point loc)
        {
            int x = this.start.X, y = this.start.Y;
            if (this.start.X > this.end.X) x = this.end.X;
            if (this.start.Y > this.end.Y) y = this.end.Y;

            if (loc.X > x && loc.X < x + Math.Abs(this.start.X - this.end.X) && loc.Y > y && loc.Y < y + Math.Abs(this.start.Y - this.end.Y)) return this;
            return null;
        }

        public void Translate(Point loc)
        {
            this.start.X += loc.X;
            this.start.Y += loc.Y;
            this.end.X += loc.X;
            this.end.Y += loc.Y;
        }

        public void RenderOnPreview()
        {

        }

        public void RenderOnStatic()
        {

        }

        public void RenderOnMoveState()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            int x = this.start.X, y = this.start.Y;
            if (this.start.X > this.end.X) x = this.end.X;
            if (this.start.Y > this.end.Y) y = this.end.Y;
            if (this.graph != null)
            {
                this.graph.SmoothingMode = SmoothingMode.AntiAlias;
                this.graph.DrawRectangle(pen, x, y, Math.Abs(this.start.X - this.end.X), Math.Abs(this.start.Y - this.end.Y));
            }
        }

    }
}
