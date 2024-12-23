using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using SpaceBattle_workspace;

namespace SpaceBattle_Tests;

public class InjectableCommandTest
{
    [Fact]
    public void InjectableCommand_DefaultConstructorKaifuet()
    {
        var injectable = new InjectableCommand();
        Assert.Null(Record.Exception(() => injectable.Execute()));
    }

    [Fact]
    public void InjectableCommand_Inject_ChangesCommand()
    {
        var injectable = new InjectableCommand();
        var cmd = new Mock<Hwdtech.ICommand>();
        injectable.Inject(cmd.Object);
        injectable.Execute();

        cmd.Verify(x => x.Execute());
    }
}