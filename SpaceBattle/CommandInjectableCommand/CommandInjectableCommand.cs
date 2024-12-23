using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle_workspace;


using Hwdtech;

public class RegisterDependencyCommandInjectableCommand : ICommand
{
    public void Execute()
    {
        IoC.Resolve<ICommand>(
            "IoC.Register",
            "Commands.CommandInjectable",
            (object[] args) => new InjectableCommand()
        ).Execute();
    }
}