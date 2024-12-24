namespace SpaceBattle_Tests;

using Hwdtech;
using Hwdtech.Ioc;
using SpaceBattle_workspace;
public class RegisterIoCDependencyActionsStartTests
{
    public RegisterIoCDependencyActionsStartTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set",
        IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }

    [Fact]
    public void RegisterIoCDependencyActionsStart_Should_Register_Start_Command()
    {
        var gameObject = new Dictionary<string, object>();

        new RegisterIoCDependencyActionsStart().Execute();
        var command = IoC.Resolve<Hwdtech.ICommand>("Actions.Start", gameObject, "Move");

        Assert.IsType<ActionStart>(command);
    }
}