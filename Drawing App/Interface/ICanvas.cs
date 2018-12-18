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
        void AddDrawingObjectAt(int index, IDrawingObject obj);
        void RemoveDrawingObject(IDrawingObject obj);

        IDrawingObject SelectObjectAt(System.Drawing.Point loc);
        void DeselectAllObject();
        void Undo();
        void Redo();
        void AddCommand(ICommand command);
        void RemoveCommand(ICommand command);
    }
}