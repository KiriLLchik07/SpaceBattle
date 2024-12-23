namespace SpaceBattle_workspace;

public class ActionStop : Hwdtech.ICommand
{
    private readonly IDictionary<string, object> _gameObject;
    private readonly string _cmdType;

    public ActionStop(IDictionary<string, object> gameObject, string cmdType)
    {
        _gameObject = gameObject;
        _cmdType = cmdType;
    }

    public void Execute()
    {
        var injectableKey = $"repeatable{_cmdType}";

        if (!_gameObject.ContainsKey(injectableKey))
        {
            throw new InvalidOperationException($"Операция {_cmdType} не была начата");
        }

        var injectable = (ICommandInjectable)_gameObject[injectableKey];
        injectable.Inject(new EmptyCommand());
        _gameObject.Remove(injectableKey);
    }
}