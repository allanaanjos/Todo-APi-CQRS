using Todo.Domain.Commands;
using Todo.Domain.Handler;
using Todo.Domain.Teste.FakeRepository;

namespace Todo.Domain.Teste.HandlerTeste
{
    [TestClass]
    public class CreateTodoHandlerTeste
    {
        private readonly CreateTodoCommand _InvalidCommand = new CreateTodoCommand("", DateTime.Now,"");
        private readonly CreateTodoCommand _ValidCommand = new CreateTodoCommand("CommandTeste", DateTime.Now,"allananjos");
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_Um_comando_invalido_deve_interomper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handler(_InvalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_Um_comando_valido_deve_criar_a_tarefa()
        {
           _result = (GenericCommandResult)_handler.Handler(_ValidCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}