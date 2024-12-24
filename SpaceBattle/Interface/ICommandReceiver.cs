namespace SpaceBattle_workspace;

public interface ICommandReceiver : Hwdtech.ICommand
{
    void Receive(Hwdtech.ICommand cmd);
}