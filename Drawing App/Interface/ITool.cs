using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;
namespace Drawing_App
{
    interface ITool
    {
        ICanvas TargetCanvas { get; set; }
        void OnMouseDown(object sender, MouseEventArgs e);
        void OnMouseUp(object sender, MouseEventArgs e);
        void OnMouseMove(object sender, MouseEventArgs e);
    }
}