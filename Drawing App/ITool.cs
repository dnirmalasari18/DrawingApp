using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Drawing_App
{
    interface ITool
    {
        ITool GetTool();
        Control GetControl();

        ICanvas Canvas { get; set; }
        void OnMouseDown(Point x);
        void OnMouseUp(Point x);
    }
}
