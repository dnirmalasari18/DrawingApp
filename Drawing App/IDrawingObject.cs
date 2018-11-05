using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drawing_App
{
    interface IDrawingObject
    {
        Point From { get; set; }
        Point To { get; set; }
        void SwapX();
        void SwapY();
        void Draw(Graphics g, Pen p);
    }
}
