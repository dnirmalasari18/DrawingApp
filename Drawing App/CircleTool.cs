using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_App
{
    class CircleTool: Button, ITool
    {
        Point A;
        ICanvas canvas;

        public ICanvas Canvas { get { return this.canvas; } set { this.canvas = value; } }
        public ITool GetTool() { return this; }
        public Control GetControl() { return this; }

        public CircleTool()
        {
            this.Size = new Size(46, 23);
            this.Location = new Point(2, 50);
            this.Text = "Circle";
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
            var circle= new Circle()
            {
                From = this.A, To = point
            };

            canvas.AddDrawingObject(circle);
        }

    }
}
