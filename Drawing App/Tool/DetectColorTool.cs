using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Drawing_App.Interface;
using System.Drawing;
namespace Drawing_App.Tool
{
    public class DetectColorTool : ToolStripButton, ITool
    {
        ICanvas canvas;
        ColorPicker cp;
        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }


        public DetectColorTool()
        {
            this.Name = "DetectColor Tool";
            this.Text = "Detect";
            this.CheckOnClick = true;
            this.cp = ColorPicker.GetInstance();
            
        }



        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IDrawingObject obj = this.canvas.SelectObjectAt(e.Location);
                if (obj != null)
                {
                    this.cp.ActiveColor = obj.ActiveColor;
                }
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
            this.canvas.DeselectAllObject();
        }

    }
}