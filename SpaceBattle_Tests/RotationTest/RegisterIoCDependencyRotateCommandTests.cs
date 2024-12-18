using System;
using System.Collections.Generic;
using System.Linq;
using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using SpaceBattle_workspace;

namespace SpaceBattle_workspace_Tests;

public class RotateCommandIoCTests
{
    public RotateCommandIoCTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
    }

    [Fact]
    public void Execute_ShouldRegisterRotateCommandDependency()
    {
        var mockRotate = new Mock<IRotatingObject>();
        var mockGameObject = new Mock<IDictionary<string, object>>();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Adapters.IRotatingObject",
            (Func<object, IRotatingObject>)(obj =>
            {
                return mockRotate.Object;
            })).Execute();

        new RegisterIoCDependencyRotateCommand().Execute();

        var rotateCommand = IoC.Resolve<SpaceBattle_workspace.ICommand>("Commands.Rotate", mockGameObject.Object);
        Assert.NotNull(rotateCommand);
        Assert.IsType<RotateCommand>(rotateCommand);
    }
}