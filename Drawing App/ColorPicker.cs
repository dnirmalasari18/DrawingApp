using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;
namespace Drawing_App
{
    class ColorPicker : IColorPick
    {
        ColorDialog cd = new ColorDialog();
        Color colorPicked;// = Color.Black;
        public Color GetColor { get { return this.colorPicked; } }
        public ColorPicker()
        {
            //this.showDialogBox();
            this.colorPicked = Color.Black;
        }

        public void showDialogBox()
        {
            //cd.ShowDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                colorPicked = cd.Color;
            }
        }

    }
}
