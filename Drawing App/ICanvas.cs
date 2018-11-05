using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Drawing_App
{
    interface ICanvas
    {
        ITool GetTool { get; set; }
        ICanvas GetCanvas();
        Control GetControl();
        List<IDrawingObject> GetDrawingObject();
        void SetMode(int x);
        void AddDrawingObject(IDrawingObject DrawObject);
        
    }
}
