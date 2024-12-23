using Hwdtech;
using SpaceBattle_workspace;

namespace SpaceBattle.Lib;

public class RegisterIoCDependencyActionsStop : Hwdtech.ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Actions.Stop",
            (object[] args) =>
            {
                var gameObject = (IDictionary<string, object>)args[0];
                var cmdType = (string)args[1];

                return new ActionStop(gameObject, cmdType);
            }
        ).Execute();
    }
}