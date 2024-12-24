namespace SpaceBattle_workspace;


public interface ICommandReceiver
{
    void Receive(ICommand cmd);
}