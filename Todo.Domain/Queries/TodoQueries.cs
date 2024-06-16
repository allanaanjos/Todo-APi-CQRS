using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
             return x => user == x.User;
        }

         public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
             return x => x.User == user && x.Done;
        }

          public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
             return x => x.User == user && x.Done == false;
        }

          public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime data, bool done)
        {
             return x => x.User == user &&
                    x.Done == done &&
                    x.Date == data.Date;
        }

        public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user)
        {
          return x => x.Id == id &&  x.User == user;
        }
    }
}