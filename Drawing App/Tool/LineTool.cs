using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drawing_App.Interface;
using Drawing_App.DrawingObject;
namespace Drawing_App.Tool
{
    class LineTool : ToolStripButton, ITool
    {
        ICanvas canvas;
        Line line;

        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }

        public LineTool()
        {
            this.Name = "Line Tool";
            this.Text = "Line";
            this.CheckOnClick = true;
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line = new Line()
                {
                    From = e.Location,
                    To = e.Location
                };
                this.canvas.AddDrawingObject(line);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (line != null)
            {
                CreateDrawingObjectCommand cmd = new CreateDrawingObjectCommand(this.line, this.canvas);
                this.canvas.AddCommand(cmd);
                line.Deselect();
                line = null;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (line != null)
            {
                line.To = e.Location;
            }
        }
        public void OnKeyDown(object sender,KeyEventArgs e)
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