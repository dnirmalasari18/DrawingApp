using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drawing_App.Interface
{
    interface IDrawingObject
    {
        Graphics TargetGraphic { set; }
        Point From { get; set; }
        Point To { get; set; }
        event EventHandler LocationChanged;

        void Draw();
        void Select();
        void Deselect();
        void Translate(Point pos);
        IDrawingObject Intersect(Point pos);

        List<IDrawingObject> GetComponent();
        void AddComponent(IDrawingObject obj);
        void RemoveComponent(IDrawingObject obj);

        void RenderOnPreview();
        void RenderOnStatic();
        void RenderOnMoveState();
    }
}