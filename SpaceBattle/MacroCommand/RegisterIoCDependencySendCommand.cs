using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle_workspace;

public class RegisterIoCDependencySendCommand : Hwdtech.ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Commands.Send",
                (object[] args) => (ICommand)new SendCommand((ICommand)args[0], (ICommandReceiver)args[1])).Execute();
    }
}