using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Drawing_App.Interface;
namespace Drawing_App.Tool
{
    class SelectTool : ToolStripButton, ITool
    {
        ICanvas canvas;
        List<IDrawingObject> targetObj;
        bool StateShiftDown, StateLeftMouseDown;
        Point lastPoint, lastDiff;
        bool Move;
        public SelectTool()
        {
            this.Name = "Select Tool";
            this.Text = "Select";
            this.CheckOnClick = true;
            this.targetObj = new List<IDrawingObject>();
            this.StateShiftDown = false;
            this.StateLeftMouseDown = false;
            this.Move = false;
        }
        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            this.StateLeftMouseDown = true;
            if (StateShiftDown)
            {
                IDrawingObject temp = this.TargetCanvas.SelectObjectAt(e.Location);
                if (temp != null)
                {
                    if (this.targetObj.Contains(temp))
                    {
                        this.targetObj.Remove(temp);
                        temp.Deselect();
                    }
                    else
                    {
                        this.targetObj.Add(temp);
                        lastPoint = e.Location;
                    }
                }
                else
                {
                    foreach (IDrawingObject obj in this.targetObj) obj.Deselect();
                    this.targetObj.Clear();
                }
            }
            else
            {
                foreach (IDrawingObject obj in this.targetObj) obj.Deselect();
                this.targetObj.Clear();
                IDrawingObject temp = this.TargetCanvas.SelectObjectAt(e.Location);
                if (temp != null)
                {
                    this.targetObj.Add(temp);
                    lastPoint = e.Location;
                }
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (Move)
            {
                foreach (IDrawingObject obj in this.targetObj)
                {
                    TranslateCommand command = new TranslateCommand(obj, lastDiff);
                    this.canvas.AddCommand(command);
                }
                Move = false;
            }

            StateLeftMouseDown = false;
            this.lastDiff = new Point(0, 0);
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (StateLeftMouseDown && this.targetObj.Any())
            {
                int diffX = e.Location.X - lastPoint.X;
                int diffY = e.Location.Y - lastPoint.Y;
                foreach (IDrawingObject obj in this.targetObj)
                {
                    obj.Translate(lastDiff);
                    obj.Translate(new Point(diffX, diffY));
                }
                this.lastDiff = new Point(-diffX, -diffY);
                this.Move = true;
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Shift | Keys.ShiftKey:
                    this.StateShiftDown = true;
                    break;

                case Keys.Control | Keys.G:
                    if (this.targetObj.Count() > 1)
                    {
                        for (int i = 1; i < this.targetObj.Count; i++)
                        {
                            this.targetObj[0].AddComponent(this.targetObj[i]);
                            this.TargetCanvas.RemoveDrawingObject(this.targetObj[i]);
                        }
                    }
                    break;

                case Keys.Control | Keys.H:
                    List<IDrawingObject> temp = this.targetObj[0].GetComponent();
                    foreach (IDrawingObject obj in temp.ToList())
                    {
                        this.targetObj[0].RemoveComponent(obj);
                        this.targetObj.Add(obj);
                        this.TargetCanvas.AddDrawingObject(obj);
                    }
                    break;
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.ShiftKey:
                    this.StateShiftDown = false;
                    break;

                case Keys.Control | Keys.G:
                    break;

                case Keys.Control | Keys.H:
                    break;
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.canvas.ActiveTool = this;
            this.canvas.DeselectAllObject();
        }
    }
}
