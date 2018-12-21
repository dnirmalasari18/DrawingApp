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

        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos,int YPos);

        /*[DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out Point pt);*/

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        public DetectColorTool()
        {
            this.Name = "DetectColor Tool";
            this.Text = "Detect";
            this.CheckOnClick = true;
            this.cp = ColorPicker.GetInstance();
            
        }
        public void Get(Point pos)
        {
            /*IntPtr dc = GetWindowDC(IntPtr.Zero);


            long color = GetPixel(dc, pos.X, pos.Y);
            Color cc = Color.FromArgb((int)color);
            
            Console.WriteLine("Detecting color:" + cc);*/
            /*IDrawingObject obj = this.canvas.SelectObjectAt(pos);
            if (obj != null)
            {
                Color cc = obj.ActiveColor;
                return cc;
            }
            return null;*/
        }


        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*Color col = this.Get(e.Location);
                this.cp.ActiveColor = col;*/
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