using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Drawing_App.Interface;
namespace Drawing_App
{
    class SelectTool : ToolStripButton, ITool
    {
        ICanvas canvas;
        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.Text = "Select";
            this.CheckOnClick = true;
            
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            this.canvas.SelectObjectAt(e.Location);
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            this.canvas.ActiveTool = this;
            Console.WriteLine("Tool has been changed to " + this.Name);
        }
    }
}
