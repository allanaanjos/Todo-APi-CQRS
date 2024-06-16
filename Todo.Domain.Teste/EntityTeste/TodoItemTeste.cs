using Todo.Domain.Entities;

namespace Todo.Domain.Teste.EntityTeste
{
    [TestClass]
    public class TodoItemTeste
    {
       private readonly TodoItem _todo = new TodoItem("Teste",DateTime.Now,"allananjos");

        [TestMethod]
        public void TestMethod1() =>
          Assert.AreEqual(_todo.Done,false);
    }
}