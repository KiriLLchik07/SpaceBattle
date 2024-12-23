using Hwdtech;
using SpaceBattle_workspace;

public class RegisterDependencyCommandInjectableCommand : Hwdtech.ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Commands.CommandInjectable",
            (object[] args) => new InjectableCommand()
        ).Execute();
    }
}