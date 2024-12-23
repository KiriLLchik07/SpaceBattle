namespace SpaceBattle_workspace;

public class QueueCommandReceiver : ICommandReceiver
{
    private readonly Queue<Hwdtech.ICommand> _queue;

    public QueueCommandReceiver(Queue<Hwdtech.ICommand> queue)
    {
        _queue = queue;
    }

    public void Receive(Hwdtech.ICommand cmd)
    {
        _queue.Enqueue(cmd);
    }

    public void Execute() { }
}