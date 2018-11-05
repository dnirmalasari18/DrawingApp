using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_App
{
    class LineTool : Button, ITool
    {
        Point A;
        ICanvas canvas;

        public ICanvas Canvas { get { return this.canvas; } set { this.canvas = value; } }
        public ITool GetTool() { return this; }
        public Control GetControl() { return this; }

        public LineTool()
        {
            this.Size = new Size(46, 23);
            this.Location = new Point(2, 0);
            this.Text = "Line";
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.canvas.GetTool = this;
            this.canvas.SetMode(DefaultCanvas.DrawMode);
        }

        public void OnMouseDown(Point point)
        {
            this.A = point;
        }

        public void OnMouseUp(Point point)
        {
            Line line = new Line();
            line.From = this.A; line.To = point;

            canvas.AddDrawingObject(line);
        }
    }
}
