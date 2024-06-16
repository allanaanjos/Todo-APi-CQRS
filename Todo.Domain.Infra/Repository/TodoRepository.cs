using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Context;
using Todo.Domain.Queries;
using Todo.Domain.Repository;

namespace Todo.Domain.Infra.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user) =>
          _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(user)).OrderBy(x => x.Date);

        public IEnumerable<TodoItem> GetAllDone(string user) =>
           _context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Date);

        public IEnumerable<TodoItem> GetAllUndone(string user) =>
           _context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(user)).OrderBy(x => x.Date);

        public TodoItem GetById(Guid id, string user) =>
        _context.Todos.AsNoTracking().FirstOrDefault(TodoQueries.GetById(id, user));

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime data, bool done) =>
          _context.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(user, data, done)).OrderBy(x => x.Date);

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}