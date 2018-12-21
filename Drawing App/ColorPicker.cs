using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Drawing_App.Interface;
namespace Drawing_App
{
    public class ColorPicker : IColorPick
    {
        ColorDialog cd = new ColorDialog();
        Color colorPicked;// = Color.Black;
        public Color GetColor { get { return this.colorPicked; } }
        public Color ActiveColor { get { return this.colorPicked; } set { this.colorPicked = value; } }
        private static ColorPicker Instance;
        public static ColorPicker GetInstance()
        {
            if (Instance == null) Instance = new ColorPicker();
            return Instance;
        }
        private ColorPicker()
        {
            //this.colorPicked = Color.Crimson;
        }

        public void ShowDialogBox()
        {
            if (cd.ShowDialog() == DialogResult.OK)
            {
                colorPicked = cd.Color;
                Console.WriteLine("Choosing color:" + colorPicked);
            }
        }

    }
}
