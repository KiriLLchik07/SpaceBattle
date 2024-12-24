namespace SpaceBattle_workspace;


public class SendCommand(ICommand cmd, ICommandReceiver receiver) : ICommand
{
    public void Execute()
    {
        receiver.Receive(cmd);
    }
}