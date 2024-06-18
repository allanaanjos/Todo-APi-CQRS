using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handler;
using Todo.Domain.Repository;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : Controller
    {

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return repository.GetAll(user);
        }


        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return repository.GetAllDone(user);
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetAllDoneForToday([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return repository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return repository.GetAllUndone(user);
        }


        [HttpGet]
        [Route("Undone/today")]
        public IEnumerable<TodoItem> GetAllUndoneForToday([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return repository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetAllDoneForTomorrow([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return repository.GetByPeriod(user, DateTime.Now.AddDays(1), true);
        }


        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<TodoItem> GetAllUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
              return repository.GetByPeriod(user, DateTime.Now.AddDays(1), false);
        }


        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone(
            [FromServices] TodoHandler handler,
            [FromBody] MarkTodoAsDoneCommand doneCommand)
        {
            doneCommand.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handler(doneCommand);
        }


        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone(
            [FromServices] TodoHandler handler,
            [FromBody] MarkTodoAsUndoneCommand doneCommand)
        {
             doneCommand.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return (GenericCommandResult)handler.Handler(doneCommand);
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
       )
        {
             command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Update(
            [FromServices] TodoHandler handler,
            [FromBody] UpdateTodoCommand command
        )
        {
             command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
             return (GenericCommandResult)handler.Handler(command);
        }
    }
}