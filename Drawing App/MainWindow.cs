using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing_App
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeToolBox();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
