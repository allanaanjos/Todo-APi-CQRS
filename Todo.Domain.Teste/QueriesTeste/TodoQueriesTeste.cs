using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Teste.QueriesTeste
{
    [TestClass]
    public class TodoQueriesTeste
    {
        private List<TodoItem> _todoList;

        public TodoQueriesTeste()
        {
            _todoList = new List<TodoItem>();
            _todoList.Add(new TodoItem("tarefa1", DateTime.Now, "allananjos"));
            _todoList.Add(new TodoItem("tarefa2", DateTime.Now, "allananjos"));
            _todoList.Add(new TodoItem("tarefa3", DateTime.Now, "allananjos"));
            _todoList.Add(new TodoItem("tarefa4", DateTime.Now, "allananjos"));
            _todoList.Add(new TodoItem("tarefa5", DateTime.Now, "usuario 1"));
            _todoList.Add(new TodoItem("tarefa6", DateTime.Now, "usuario 1"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retonar_apenas_do_usuario_allananjos()
        {
            var result = _todoList.AsQueryable().Where(TodoQueries.GetAll("allananjos"));
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_2_tarefas_Inclompletas()
        {
            var result = _todoList.AsQueryable().Where(TodoQueries.GetAllUndone("usuario 1"));
            Assert.AreEqual(2, result.Count());
        }
    }
}