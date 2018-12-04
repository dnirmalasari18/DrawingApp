using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing_App.Interface
{
    public interface ICommand
    {
        void Execute();
        void unExecute();
    }
}
