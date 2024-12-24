using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle_workspace
{
    public class CreateMacroCommandStrategy
    {
        private readonly string cmdSpec;

        public CreateMacroCommandStrategy(string cmdSpec)
        {
            this.cmdSpec = cmdSpec;
        }

        public ICommand Resolve(object[] args)
        {
            var cmdsNames = IoC.Resolve<string[]>($"Specs.{cmdSpec}");
            if (cmdsNames == null)
                throw new InvalidOperationException("No commands specified in the macro spec");

            if (cmdsNames.Length == 0)
                throw new InvalidOperationException("No commands specified in the macro spec");

            var cmds = cmdsNames.Select(name =>
            {
                var cmd = IoC.Resolve<object>(name, args);
                if (cmd is SpaceBattle_workspace.ICommand command)
                    return command;
                else
                    throw new InvalidOperationException($"Command {name} is not of type ICommand");
            }).ToArray();

            return new MacroCommand(cmds);
        }
    }
}
