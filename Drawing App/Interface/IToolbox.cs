using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drawing_App.Interface;

namespace Drawing_App
{
    interface IToolbox
    {
        void SetCanvas(ICanvas canvas);
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
    }
}
