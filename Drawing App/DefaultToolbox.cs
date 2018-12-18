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



        public void AddTool(ITool tool)
        {
            ToolStripButton temp = (ToolStripButton)tool;
            this.Items.Add(temp);
            temp.CheckedChanged += UnCheckToolStripButton;
        }

        public void RemoveTool(ITool tool)
        {
            this.Items.Remove((ToolStripButton)tool);
        }

        public void SetCanvas(ICanvas canvas)
        {
            foreach (ITool tool in this.Items)
                tool.TargetCanvas = canvas;
        }

        public void UnCheckToolStripButton(object sender, EventArgs e)
        {
            foreach (ToolStripButton tool in this.Items)
            {
                tool.Checked = false;
            }
        }
    }
}
