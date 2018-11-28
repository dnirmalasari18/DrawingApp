using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Drawing_App.Interface
{
    interface IState
    {
        void Draw(IDrawingObject obj);
        IState Next();
        IState Prev();
    }
}
