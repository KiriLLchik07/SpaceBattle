namespace SpaceBattle_workspace
{
    internal class RepeatCommand : Hwdtech.ICommand
    {
        private readonly Hwdtech.ICommand _cmd = new EmptyCommand();
        private readonly Queue<Hwdtech.ICommand> _q = new Queue<Hwdtech.ICommand>();
        public RepeatCommand(Hwdtech.ICommand cmd, Queue<Hwdtech.ICommand> q)
        {
            _cmd = cmd;
            _q = q;
        }
        public void Execute()
        {
            _q.Enqueue(_cmd);
        }
    }
}
