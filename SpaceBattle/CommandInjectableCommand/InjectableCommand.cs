

namespace SpaceBattle_workspace;

public class InjectableCommand : Hwdtech.ICommand
{
    private Hwdtech.ICommand _cmd = new EmptyCommand();

    public void Execute()
    {
        _cmd.Execute();
    }
    public void Inject(Hwdtech.ICommand cmd)
    {
        _cmd = cmd;
    }
}
