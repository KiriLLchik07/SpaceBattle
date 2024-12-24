namespace SpaceBattle_workspace;

public class SendCommand(Hwdtech.ICommand cmd, ICommandReceiver receiver) : Hwdtech.ICommand
{
    public void Execute()
    {
        receiver.Receive(cmd);
    }
}