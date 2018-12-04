using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;

namespace Drawing_App.DrawingObject
{
    class LineConnector:Line,ILocationMonitor 
    {
        IDrawingObject object1, object2;
        public IDrawingObject A
        {
            get { return this.object1; }
            set
            {
                this.object1 = value;
                //this.From.X = (value.From.X + value.To.X) / 2;
                //this.From.Y = (value.From.Y + value.To.Y) / 2;
                
            }
        }

        public IDrawingObject B
        {
            get { return this.object2; }
            set
            {
                this.object2 = value;
            }

        }
    }
}
