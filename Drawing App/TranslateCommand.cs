using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Drawing_App.Interface;
namespace Drawing_App
{
    class TranslateCommand:ICommand
    {
        IDrawingObject obj;
        Point pos;

        public TranslateCommand(IDrawingObject obj, Point pos)
        {
            this.obj = obj;
            this.pos = pos;
        }

        public void Execute()
        {
            Point temp = new Point(-this.pos.X, -this.pos.Y);
            this.obj.Translate(temp);
        }

        public void unExecute()
        {
            this.obj.Translate(this.pos);
        }
    }
}
