using Hwdtech;
using SpaceBattle_workspace;
namespace SpaceBattle_workspace;

public class RegisterIoCDependencyActionsStart : Hwdtech.ICommand
{
    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Actions.Start",
            (object[] args) =>
            {
                var gameObject = (IDictionary<string, object>)args[0];
                var cmdType = (string)args[1];
                var q = new Queue<Hwdtech.ICommand>();

                return new ActionStart(gameObject, q, cmdType);
            }
        ).Execute();
    }
}