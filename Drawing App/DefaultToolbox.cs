using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;

namespace Drawing_App
{
    class DefaultToolbox : ToolStrip, IToolbox
    {
        public DefaultToolbox()
        {

        }

        public void SetCanvas(ICanvas canvas)
        {
            foreach (ITool tool in this.Items)
                tool.TargetCanvas = canvas;
        }

        public void AddTool(ITool tool)
        {
            ToolStripButton temp = (ToolStripButton)tool;
            this.Items.Add(temp);
            Console.WriteLine(tool.ToString() + " is added to your toolbox");
        }

        public void RemoveTool(ITool tool)
        {
            ToolStripButton temp = (ToolStripButton)tool;
            this.Items.Add(temp);
            Console.WriteLine(tool.ToString() + " is removed to your toolbox");
        }
    }
}
