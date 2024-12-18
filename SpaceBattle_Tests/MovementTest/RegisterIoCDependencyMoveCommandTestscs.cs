using Moq;
using SpaceBattle_workspace;
using Hwdtech;

namespace SpaceBattle_Tests;

public class MoveCommandIoCTests
{
    [Fact]
    public void Execute_ShouldRegisterMoveCommandDependency()
    {
        var mockMoving = new Mock<IMoving>();
        var mockGameObject = new Mock<IDictionary<string, object>>();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Adapters.IMoving",
            (Func<object, IMoving>)(obj =>
            {
                return mockMoving.Object;
            })).Execute();

        new RegisterIoCDependencyMoveCommand().Execute();

        var moveCommand = IoC.Resolve<SpaceBattle_workspace.ICommand>("Commands.Move", mockGameObject.Object);
        Assert.NotNull(moveCommand);
        Assert.IsType<MoveCommand>(moveCommand);
    }
}
