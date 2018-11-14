using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawing_App.Interface;
namespace Drawing_App
{
    interface IState
    {
        void Draw(IDrawingObject obj);
        IState Next();
        IState Prev();
    }
}
