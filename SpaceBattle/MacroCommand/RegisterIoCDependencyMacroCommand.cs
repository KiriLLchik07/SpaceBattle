using Hwdtech.Ioc;
using Hwdtech;
namespace SpaceBattle_workspace;

public class RegisterIoCDependencyMacroCommand : Hwdtech.ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Commands.Macro",
            (object[] args) => (SpaceBattle_workspace.ICommand)new SimpleMacroCommand(args.Select(x => (SpaceBattle_workspace.ICommand)x).ToArray())).Execute();
    }
}