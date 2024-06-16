using Microsoft.VisualBasic;
using Todo.Domain.Commands;

namespace Todo.Domain.Teste.TodoComandsTeste;

[TestClass]
public class UnitTest1
{
    private readonly CreateTodoCommand  _InvalidCommand = new CreateTodoCommand("", DateTime.Now,"");
    private readonly CreateTodoCommand  _ValidCommand = new CreateTodoCommand("CommandTeste", DateTime.Now,"allananjos");

    public UnitTest1()
    {
        _ValidCommand.Validate();
        _InvalidCommand.Validate();
    }

    [TestMethod]
    public void Dado_Um_comando_invalido() =>
        Assert.AreEqual(_InvalidCommand.Valid, false);

    [TestMethod]
    public void Dado_Um_comando_valido() =>
      Assert.AreEqual(_ValidCommand.Valid, true);
}