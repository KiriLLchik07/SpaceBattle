using Hwdtech.Ioc;
using Hwdtech;
using Moq;
using SpaceBattle_workspace;
namespace SpaceBattle_Tests;
public class RegisterDependencyCommandInjectableCommandTests
{
    public RegisterDependencyCommandInjectableCommandTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set",
        IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }

    [Fact]
    public void RegisterDependencyCommandInjectableCommand_Success()
    {
        new RegisterDependencyCommandInjectableCommand().Execute();

        var cmd1 = IoC.Resolve<Hwdtech.ICommand>("Commands.CommandInjectable");
        var cmd2 = IoC.Resolve<ICommandInjectable>("Commands.CommandInjectable");
        var cmd3 = IoC.Resolve<InjectableCommand>("Commands.CommandInjectable");

        var cmd = new Mock<Hwdtech.ICommand>();
        ((ICommandInjectable)cmd1).Inject(cmd.Object);
        cmd1.Execute();
        cmd.Verify(c => c.Execute(), Times.Once());
    }
}