
using Hwdtech;
using SpaceBattle.Interface;

namespace SpaceBattle_workspace;

public class ActionStart : Hwdtech.ICommand
{
    private readonly IDictionary<string, object> _gameObject;
    private readonly Queue<Hwdtech.ICommand> _q;
    private readonly string _cmdType;

    public ActionStart(IDictionary<string, object> gameObject, Queue<Hwdtech.ICommand> q, string cmdType)
    {
        _gameObject = gameObject;
        _q = q;
        _cmdType = cmdType;
    }

    public void Execute()
    {
        var cmd = IoC.Resolve<Hwdtech.ICommand>($"Commands.{_cmdType}", _gameObject);
        var injectable = (Hwdtech.ICommand)IoC.Resolve<ICommandInjectable>("Commands.CommandInjectable");
        var repeat = new RepeatCommand(injectable, _q);
        var repeatable = IoC.Resolve<ICommand>($"Macro.{_cmdType}", cmd, repeat);

        ((ICommandInjectable)injectable).Inject(repeatable);
        _gameObject[$"repeatable{_cmdType}"] = injectable;
        _q.Enqueue(repeatable);
    }
}
