using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Drawing_App
{
    class DefaultToolbox : Control, IToolbox
    {
        List<ITool> toolList;
        public Control GetControl() { return this; }

        public DefaultToolbox()
        {
            this.toolList = new List<ITool>();
            //this.toolList.Add(new MoveTool());
            //this.toolList.Add(new UndoTool());
            this.toolList.Add(new LineTool());
            this.toolList.Add(new CircleTool());
            this.toolList.Add(new SquareTool());
            this.BackColor = Color.DarkGray;

            int i = 0;
            foreach (ITool tool in toolList)
            {
                tool.GetControl().Location = new Point(2, i * 25);
                this.Controls.Add(tool.GetControl());
                i++;
            }
        }

        public void SetCanvas(ICanvas canvas)
        {
            foreach (ITool tool in toolList)
                tool.Canvas = canvas;
        }

        public void AddTool(ITool tool)
        {
            this.toolList.Add(tool);
        }

        public void RemoveTool(int x)
        {
            this.toolList.RemoveAt(x);
        }
    }
}
