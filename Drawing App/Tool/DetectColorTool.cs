using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawing_App.Interface;
namespace Drawing_App.Tool
{
    public class DetectColorTool : ToolStripButton, ITool
    {
        ICanvas canvas;
        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }
        public DetectColorTool()
        {
            this.Name = "Color Tool";
            this.Text = "Detect";
            this.CheckOnClick = true;
            
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Console.WriteLine("debug");
                
            }

        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {

        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {

        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.canvas.ActiveTool = this;
            //this.canvas.DeselectAllObject();
        }

    }
}