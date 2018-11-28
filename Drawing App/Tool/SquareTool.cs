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
    class SquareTool:ToolStripButton, ITool
    {
        ICanvas canvas;
        Square square;

        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }

        public SquareTool()
        {
            this.Name = "Square Tool";
            this.Text = "Square";
            this.CheckOnClick = true;
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                square = new Square()
                {
                    From = e.Location,
                    To = e.Location
                };
                this.canvas.AddDrawingObject(square);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (square != null)
            {
                square.Deselect();
                square = null;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (square != null)
            {
                square.To = e.Location;
            }
        }
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            this.canvas.ActiveTool = this;
            Console.WriteLine("Tool has been changed to " + this.Name);
        }
    }
}
