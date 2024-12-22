namespace SpaceBattle_workspace;

public interface ICommandReceiver : ICommand
{
    void Receive(ICommand cmd);
}