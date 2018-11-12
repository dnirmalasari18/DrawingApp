using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Drawing_App
{
    interface IToolItem
    {
        IToolItem GetToolItem();
        Control GetControl();
    }
}
