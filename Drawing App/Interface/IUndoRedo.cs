using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing_App.Interface
{
    public interface IUndoRedo
    {
        void AddCommand(ICommand command);
        void RemoveCommand(ICommand command);

        void Undo();
        void Redo();
    }
}
