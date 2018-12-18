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
                this.start.X = (value.From.X + value.To.X) / 2;
                this.start.Y = (value.From.Y + value.To.Y) / 2;
                value.LocationChanged += LocationHasChanged;
            }
        }

        public IDrawingObject B
        {
            get { return this.object2; }
            set
            {
                this.object2 = value;
                this.start.X = (value.From.X + value.To.X) / 2;
                this.start.Y = (value.From.Y + value.To.Y) / 2;
                value.LocationChanged += LocationHasChanged;
            }

        }

        public LineConnector()
        {

        }

        void LocationHasChanged(object sender, EventArgs e)
        {
            this.start.X = (object1.From.X + object1.To.X) / 2;
            this.start.Y = (object1.From.Y + object1.To.Y) / 2;
            this.end.X = (object2.From.X + object2.To.X) / 2;
            this.end.X = (object2.From.Y + object2.To.Y) / 2;
        }

        double GetSlope(Point pos1, Point pos2)
        {
            return (double)(pos2.Y-pos1.Y) /(double)(pos2.X-pos1.X);
            
        }
    }
}
