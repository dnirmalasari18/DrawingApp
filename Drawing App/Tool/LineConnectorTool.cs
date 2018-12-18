using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;
using Drawing_App.DrawingObject;
namespace Drawing_App.Tool
{
    class LineConnectorTool:ToolStripButton,ITool
    {
        ICanvas canvas;
        LineConnector lineConnector;

        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }

        public LineConnectorTool()
        {
            this.Name = "LineConnector Tool";
            this.Text = "LineConnector";
            this.CheckOnClick = true;
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IDrawingObject temp = this.TargetCanvas.SelectObjectAt(e.Location);
                lineConnector = new LineConnector()
                {
                    A = temp,
                    To = e.Location
                    
                };
                this.TargetCanvas.AddDrawingObject(lineConnector);
                temp.Deselect();
                this.canvas.AddDrawingObject(lineConnector);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if(lineConnector != null)
            {
                IDrawingObject temp = this.TargetCanvas.SelectObjectAt(e.Location);
                if (temp == null) this.TargetCanvas.RemoveDrawingObject(lineConnector);
                else
                {
                    lineConnector.B = temp;
                    lineConnector.B = temp;
                    //CreateDrawingObjectCommand cmd = new CreateDrawingObjectCommand(this.lineConnector, this.TargetCanvas);
                   // this._targetCanvas.AddCommand(cmd);
                    lineConnector.Deselect();
                    this.TargetCanvas.RemoveDrawingObject(lineConnector);
                    this.TargetCanvas.AddDrawingObjectAt(0, lineConnector);
                    lineConnector = null;
                }
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (lineConnector != null)
            {
                lineConnector.To = e.Location;
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
