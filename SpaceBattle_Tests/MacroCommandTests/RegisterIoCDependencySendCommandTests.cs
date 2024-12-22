using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using SpaceBattle_workspace;

namespace SpaceBattle_Tests
{
    public class RegisterIoCDependencySendCommandTests
    {
        public RegisterIoCDependencySendCommandTests()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set",
            IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        }

        [Fact]
        public void SendCommand_Should_Send_A_Command_To_The_Command_Receiver()
        {
            var receiver = new Mock<ICommandReceiver>();
            var cmd = new Mock<SpaceBattle_workspace.ICommand>();

            new RegisterIoCDependencySendCommand().Execute();

            IoC.Resolve<Hwdtech.ICommand>("Commands.Send", new object[] { cmd.Object, receiver.Object }).Execute();

            receiver.Verify(r => r.Receive(cmd.Object), Times.Once());
        }
    }
}