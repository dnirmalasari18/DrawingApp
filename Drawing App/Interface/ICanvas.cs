using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Drawing_App.Interface;

namespace Drawing_App
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