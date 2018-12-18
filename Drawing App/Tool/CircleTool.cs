using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Drawing_App.Interface;
using Drawing_App.DrawingObject;

namespace Drawing_App.Tool
{
    class CircleTool : ToolStripButton, ITool
    {
        ICanvas canvas;
        Circle circle;

        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }

        public CircleTool()
        {
            this.Name = "Circle Tool";
            this.Text = "Circle";
            this.CheckOnClick = true;
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                circle = new Circle()
                {
                    From = e.Location,
                    To = e.Location
                };
               this.canvas.AddDrawingObject(circle);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (circle != null)
            {
                circle.Deselect();
                circle = null;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (circle != null)
            {
                circle.To = e.Location;
            }
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {

        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {

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
