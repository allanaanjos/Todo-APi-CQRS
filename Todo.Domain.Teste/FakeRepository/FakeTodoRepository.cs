using Todo.Domain.Entities;
using Todo.Domain.Repository;

namespace Todo.Domain.Teste.FakeRepository
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
            
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid Id, string User)
        {
            return new TodoItem("Nova tarefa", DateTime.Now, "Allananjos");
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime data, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {
            
        }
    }
}