using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_App.Interface
{
    interface IToolbar
    {
        IToolbar GetToolbar();
        Control GetControl();
        void AddTool(Control control);
    }
}
