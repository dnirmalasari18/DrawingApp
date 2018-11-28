﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Drawing_App.Interface
{
    interface IDrawingObject
    {
        Point From { get; set; }
        Point To { get; set; }
        Graphics TargetGraphic { set; }
        void Draw();
        void Select();
        void Deselect();
        void Translate(Point pos);
        IDrawingObject Intersect(Point pos);
        void RenderOnPreview();
        void RenderOnStatic();
        void RenderOnMoveState();
    }
}