using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using SpaceBattle_workspace;

namespace SpaceBattle_Tests
{
    public class RegisterIoCDependencyMacroMoveRotateTests
    {
        public RegisterIoCDependencyMacroMoveRotateTests()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set",
            IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        }

        [Fact]
        public void MacroMoveRotate_Dependencies_Should_Be_Registered()
        {
            var iocScope = IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"));
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", iocScope).Execute();

            var cmd1 = new Mock<SpaceBattle_workspace.ICommand>();
            var cmd2 = new Mock<SpaceBattle_workspace.ICommand>();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Specs.Move",
                (object[] args) => new string[] { "Command1", "Command2" }).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Command1",
                (object[] args) => cmd1.Object).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Command2",
                (object[] args) => cmd2.Object).Execute();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Specs.Rotate",
                (object[] args) => new string[] { "Command1", "Command2" }).Execute();

            IoC.Resolve<Hwdtech.ICommand>(
                "IoC.Register",
                "Commands.Macro",
                (Func<object[], object>)((args) => new MacroCommand((SpaceBattle_workspace.ICommand[])args))
            ).Execute();

            new RegisterIoCDependencyMacroMoveRotate().Execute();

            var moveMacro = IoC.Resolve<SpaceBattle_workspace.ICommand>("Macro.Move");
            moveMacro.Execute();
            cmd1.Verify(c => c.Execute(), Times.Once());
            cmd2.Verify(c => c.Execute(), Times.Once());
        }
    }
}