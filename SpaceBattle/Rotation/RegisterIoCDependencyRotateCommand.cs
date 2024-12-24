using Hwdtech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle_workspace;

public class RegisterIoCDependencyRotateCommand : Hwdtech.ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Commands.Rotate",
            (Func<object, object>)(obj =>
            new RotateCommand(IoC.Resolve<IRotatingObject>("Adapters.IRotatingObject", obj)))).Execute();
    }
}