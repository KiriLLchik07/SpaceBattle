using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBattle_workspace;

namespace SpaceBattle.Interface
{
    internal interface ICommandInjectable
    {
    void Inject(Hwdtech.ICommand cmd);
    }
}
