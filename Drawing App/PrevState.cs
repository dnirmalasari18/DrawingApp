using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing_App.Interface;

namespace Drawing_App
{
    class PrevState :IState
    {
        private static PrevState instance;

        public static IState GetInstance()
        {
            if (instance == null)
            {
                instance = new PrevState();
            }
            return instance;
        }
        public void Draw(IDrawingObject obj)
        {
            obj.RenderOnPreview();
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
