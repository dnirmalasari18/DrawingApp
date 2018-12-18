using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawing_App.Interface;
namespace Drawing_App.UndoRedoCommand
{
    class DefaultUndoRedo:IUndoRedo
    {
        ICanvas targetCanvas;
        List<ICommand> undoStack;
        List<ICommand> redoStack;

        public DefaultUndoRedo(ICanvas canvas)
        {
            this.targetCanvas = canvas;
            this.undoStack = new List<ICommand>();
            this.redoStack = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            this.undoStack.Add(command);
            this.redoStack.Clear();
        }

        public void RemoveCommand(ICommand command)
        {
            this.undoStack.Remove(command);
        }

        public void Undo()
        {
            if (this.undoStack.Count > 0)
            {
                ICommand temp = this.undoStack.Last();
                temp.unExecute();
                redoStack.Add(temp);
                undoStack.Remove(temp);
            }
        }

        public void Redo()
        {
            if (this.redoStack.Count > 0)
            {
                ICommand temp = this.redoStack.Last();
                temp.Execute();
                undoStack.Add(temp);
                redoStack.Remove(temp);
            }
        }
    }
}
