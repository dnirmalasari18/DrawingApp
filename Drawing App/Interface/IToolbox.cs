﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_App.Interface
{
    interface IToolbox
    {
        void SetCanvas(ICanvas canvas);
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
    }
}
