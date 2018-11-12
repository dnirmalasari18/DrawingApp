using System.Drawing;
using System.Windows.Forms;

namespace Drawing_App
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 450);
            this.Name = "MainWindow";
            this.Text = "Drawing Application";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private void InitializeCanvas()
        {
            ///
            /// Canvas
            ///
            this.canvas = new DefaultCanvas();
            this.canvas.GetControl().Location = new Point(50, 0);
            this.canvas.GetControl().Size = this.ClientSize;
            this.canvas.GetControl().BackColor = Color.White;
            this.Controls.Add(canvas.GetControl());
        }

        private void InitializeToolBox()
        {
            ///
            /// Toolbox
            ///          
            this.toolbox = new DefaultToolbox();
            this.toolbox.SetCanvas(this.canvas);
            this.toolbox.GetControl().Location = new Point(0, 0);
            this.toolbox.GetControl().Size = new Size(50, this.ClientSize.Height);
            this.Controls.Add(this.toolbox.GetControl());
        }

        private ICanvas canvas = null;
        private IToolbox toolbox = null;
    }
}