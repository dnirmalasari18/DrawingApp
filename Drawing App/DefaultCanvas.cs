using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Drawing_App.Interface;
using Drawing_App.UndoRedoCommand;
namespace Drawing_App
{
    class DefaultCanvas : Control, ICanvas
    {
        List<IDrawingObject> ObjectToDraw;
        ITool Tool;
        public ITool ActiveTool { get { return this.Tool; } set { this.Tool = value; } }
        
        IUndoRedo undoRedo;

        public DefaultCanvas()
        { 
            //Console.WriteLine(colorPick);
            this.ObjectToDraw = new List<IDrawingObject>();
            this.DoubleBuffered = true;
            this.Tool = null;

            this.undoRedo = new DefaultUndoRedo(this);
        }
        public void AddDrawingObject(IDrawingObject obj)
        {
            this.ObjectToDraw.Add(obj);
        }

        public void AddDrawingObjectAt(int index, IDrawingObject obj)
        {
            this.ObjectToDraw.Insert(index, obj);
        }

        public void RemoveDrawingObject(IDrawingObject obj)
        {
            this.ObjectToDraw.Remove(obj);
        }

        public IDrawingObject SelectObjectAt(Point pos)
        {
            IDrawingObject selected = null;

            foreach (IDrawingObject obj in ObjectToDraw)
            {
                selected = obj.Intersect(pos);
                if (selected != null)
                {
                    selected.Select();
                    break;
                }
            }
            return selected;
        }

        public void DeselectAllObject()
        {
            foreach (IDrawingObject obj in this.ObjectToDraw)
                obj.Deselect();
        }

        public void AddCommand(ICommand command)
        {
            this.undoRedo.AddCommand(command);
        }

        public void RemoveCommand(ICommand command)
        {
            this.undoRedo.RemoveCommand(command);
        }

        public void Undo()
        {
            this.undoRedo.Undo();
            this.Invalidate();
            this.Update();
        }

        public void Redo()
        {
            this.undoRedo.Redo();
            this.Invalidate();
            this.Update();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (IDrawingObject obj in ObjectToDraw)
            {
                obj.TargetGraphic = e.Graphics;
                obj.Draw();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Tool != null)
            {
                this.Tool.OnMouseDown(this, e);
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.Tool != null)
            {
                this.Tool.OnMouseUp(this, e);
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.Tool != null)
            {
                this.Tool.OnMouseMove(this, e);
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (this.Tool != null)
            {
                this.Tool.OnKeyDown(this, e);
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.Tool != null)
            {
                this.Tool.OnKeyUp(this, e);
                this.Invalidate();
                this.Update();
            }
        }
        /*public void SelectColor()
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
        }*/
    }
}