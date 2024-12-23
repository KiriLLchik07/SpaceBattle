using SpaceBattle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle_workspace;

public class InjectableCommand : Hwdtech.ICommand
{
    private Hwdtech.ICommand _cmd = new EmptyCommand();

    public void Execute()
    {
        _cmd.Execute();
    }
    public void Inject(Hwdtech.ICommand cmd)
    {
        _cmd = cmd;
    }
}
