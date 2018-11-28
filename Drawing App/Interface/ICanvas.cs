using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Drawing_App.Interface
{
    interface ICanvas
    {
        ITool ActiveTool { get; set; }
        
        void AddDrawingObject(IDrawingObject DrawObject);
        void RemoveDrawingObject(IDrawingObject obj);

        IDrawingObject SelectObjectAt(System.Drawing.Point loc);
        void DeselectAllObject();
    }
}