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
        ColorPicker cp;
        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }
        public SquareTool()
        {
            this.Name = "Square Tool";
            this.Text = "Square";
            this.CheckOnClick = true;
            this.cp = ColorPicker.GetInstance();
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
                square.ActiveColor = cp.GetColor;
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (square != null)
            {
                CreateDrawingObjectCommand cmd = new CreateDrawingObjectCommand(this.square, this.canvas);
                this.canvas.AddCommand(cmd);
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
