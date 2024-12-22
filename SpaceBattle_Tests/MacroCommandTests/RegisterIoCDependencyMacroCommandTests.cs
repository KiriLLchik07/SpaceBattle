using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using SpaceBattle_workspace;

namespace SpaceBattle_Tests
{
    public class RegisterIoCDependencyMacroCommandTests
    {
        public RegisterIoCDependencyMacroCommandTests()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
        }

        [Fact]
        public void Execute_ShouldRegisterMacroCommandDependency()
        {
            var iocScope = IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"));
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", iocScope).Execute();

            var command_1 = new Mock<SpaceBattle_workspace.ICommand>();
            var command_2 = new Mock<SpaceBattle_workspace.ICommand>();

            new RegisterIoCDependencyMacroCommand().Execute();

            SpaceBattle_workspace.ICommand[] commandArray = { command_1.Object, command_2.Object };

            var macroCommand = IoC.Resolve<SpaceBattle_workspace.ICommand>("Commands.Macro", commandArray);
            macroCommand.Execute();

            command_1.Verify(m => m.Execute(), Times.Once());
            command_2.Verify(m => m.Execute(), Times.Once());
        }
    }
}