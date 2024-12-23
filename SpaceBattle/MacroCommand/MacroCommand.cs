namespace SpaceBattle_workspace;

public class MacroCommand : ICommand
{
    public ICommand[] cmds;
    public MacroCommand(params ICommand[] cmds)
    {
        this.cmds = cmds;
    }
    public void Execute()
    {
        foreach (var cmd in cmds)
        {
            cmd.Execute();
        }
    }
}