using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;
namespace Drawing_App.Tool
{
    public class ColorTool:ToolStripButton,ITool
    {
        ICanvas canvas;
        IColorPick colorPick;
        ColorPicker cp;
        public ICanvas TargetCanvas { get { return this.canvas; } set { this.canvas = value; } }
        public ColorTool()
        {
            this.Name = "Color Tool";
            this.Text = "Color";
            this.CheckOnClick = true;
            this.cp = ColorPicker.GetInstance();
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
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
            //this.canvas.ActiveTool = this;
            cp.ShowDialogBox();
            this.canvas.DeselectAllObject();
        }
    }
}
