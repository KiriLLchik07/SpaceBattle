using SpaceBattle.Interface;
using Hwdtech;
namespace SpaceBattle_workspace;
public class StartCommand : Hwdtech.ICommand
{
    private readonly IDictionary<string, object> _gameObject;
    private readonly Queue<Hwdtech.ICommand> _q;
    private readonly string _cmdType;

    public StartCommand(IDictionary<string, object> gameObject, Queue<Hwdtech.ICommand> q, string cmdType)
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
        var repeatable = IoC.Resolve<Hwdtech.ICommand>($"Macro.{_cmdType}", cmd, repeat);

        ((ICommandInjectable)injectable).Inject(repeatable);
        _gameObject[$"repeatable{_cmdType}"] = injectable;

        var sendCommand = new SendCommand(repeatable, new QueueCommandReceiver(_q));
        sendCommand.Execute();
    }
}