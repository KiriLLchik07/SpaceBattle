namespace SpaceBattle_Tests;

using Hwdtech;
using Hwdtech.Ioc;
using SpaceBattle.Lib;
using SpaceBattle_workspace;
public class RegisterIoCDependencyActionsStopTests
{
    public RegisterIoCDependencyActionsStopTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set",
        IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }

    [Fact]
    public void RegisterIoCDependencyActionsStop_Should_Register_Stop_Command()
    {
        var gameObject = new Dictionary<string, object>();

        new RegisterIoCDependencyActionsStop().Execute();
        var stopcmd = IoC.Resolve<Hwdtech.ICommand>("Actions.Stop", gameObject, "Move");

        Assert.IsType<ActionStop>(stopcmd);
    }
}