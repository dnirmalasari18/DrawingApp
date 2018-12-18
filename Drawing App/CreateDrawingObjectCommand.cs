using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawing_App.Interface;
using Drawing_App.DrawingObject;
namespace Drawing_App
{
    class CreateDrawingObjectCommand:ICommand
    {
        IDrawingObject obj;
        ICanvas canvas;

        public CreateDrawingObjectCommand(IDrawingObject obj, ICanvas canvas)
        {
            this.obj = obj;
            this.canvas = canvas;
        }

        public void Execute()
        {
            if (this.obj is LineConnector)
            {
                this.canvas.AddDrawingObjectAt(0, this.obj);
            }
            else
            {
                this.canvas.AddDrawingObject(this.obj);
            }
        }

        public void unExecute()
        {
            this.canvas.RemoveDrawingObject(this.obj);
        }
    }
}
