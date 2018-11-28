using System;
using System.Drawing;
using System.Windows.Forms;
using Drawing_App.Interface;
using Drawing_App.Tool;
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
            this.Text = "Drawing App";
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
            Control temp = (Control)canvas;
            temp.Location = new Point(0, 25);
            temp.Size = this.ClientSize;
            temp.BackColor = Color.White;
            this.Controls.Add(temp);
            Console.WriteLine("Canvas Successfully Initialized");
        }

        private void InitializeToolBox()
        {
            ///
            /// Toolbox
            ///          
            this.toolbox = new DefaultToolbox();
            toolbox.AddTool(new LineTool());
            toolbox.AddTool(new SquareTool());
            toolbox.AddTool(new CircleTool());
            toolbox.AddTool(new SelectTool());
            ToolStrip temp = (ToolStrip)toolbox;
            temp.Location = new Point(0, 0);
            temp.Anchor = AnchorStyles.Left;
            this.toolbox.SetCanvas(canvas);
            this.Controls.Add(temp);
            System.Console.WriteLine("Toolbox Successfully Initialized");
        }
        
        ICanvas canvas;
        IToolbox toolbox;
    }
}