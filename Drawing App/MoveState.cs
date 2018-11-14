using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Drawing_App.Interface;

namespace Drawing_App
{
    class MoveState :IState
    {
        private static MoveState instance;

        public static IState GetInstance()
        {
            if (instance == null)
            {
                instance = new MoveState();
            }
            return instance;
        }

        public void Draw(IDrawingObject obj)
        {
            obj.RenderOnMoveState();
        }

        public IState Next()
        {
            return null;
        }

        public IState Prev()
        {
            return null;
        }
    }
}
