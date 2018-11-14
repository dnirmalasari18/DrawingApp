using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Drawing_App.Interface;

namespace Drawing_App
{
    class StaticState : IState
    {
        private static StaticState instance;

        public static IState GetInstance()
        {
            if (instance == null)
            {
                instance = new StaticState();
            }
            return instance;
        }

        public void Draw(IDrawingObject obj)
        {
            obj.RenderOnStatic();
        }

        public IState Next()
        {
            return MoveState.GetInstance();
        }

        public IState Prev()
        {
            return null;
        }
    }
}
