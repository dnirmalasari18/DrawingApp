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
    public class LineConnector:Line,ILocationMonitor 
    {
        IDrawingObject _a;
        IDrawingObject _b;
        //public override string ObjName { get { return "LineCon"; } }
        
        /*string name = "LineCon";*/
        public override string ObjName { get { return "LineCon"; } }
        public IDrawingObject A
        {
            get { return this._a; }
            set
            {
                this._a = value;
                this.start.X = (value.From.X + value.To.X) / 2;
                this.start.Y = (value.From.Y + value.To.Y) / 2;
                value.LocationChanged += LocationHasChanged;
            }
        }
        public IDrawingObject B
        {
            get { return this._b; }
            set
            {
                this._b = value;
                this.end.X = (value.From.X + value.To.X) / 2;
                this.end.Y = (value.From.Y + value.To.Y) / 2;
                value.LocationChanged += LocationHasChanged;
            }
        }

        public LineConnector()
        {
            
        }

        void LocationHasChanged(object sender, EventArgs e)
        {
            this.start.X = (_a.From.X + _a.To.X) / 2;
            this.start.Y = (_a.From.Y + _a.To.Y) / 2;
            this.end.X = (_b.From.X + _b.To.X) / 2;
            this.end.Y = (_b.From.Y + _b.To.Y) / 2;
        }

        double GetSlope(Point pos1, Point pos2)
        {
            return (double)(pos2.Y-pos1.Y) /(double)(pos2.X-pos1.X);
            
        }
    }
}
