using IGME106GroupGame.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME106GroupGame.UI
{
    public interface ClickAction
    {
        void execute(State state);
    }
}
