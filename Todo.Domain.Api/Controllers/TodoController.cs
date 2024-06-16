using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handler;
using Todo.Domain.Repository;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : Controller
    {

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository) =>
             repository.GetAll("allananjos");


        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository) =>
             repository.GetAllDone("allananjos");


        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetAllDoneForToday([FromServices] ITodoRepository repository) =>
             repository.GetByPeriod("allananjos", DateTime.Now.Date, true);


        [HttpGet]
        [Route("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository) =>
             repository.GetAllUndone("allananjos");


        [HttpGet]
        [Route("Undone/today")]
        public IEnumerable<TodoItem> GetAllUndoneForToday([FromServices] ITodoRepository repository) =>
             repository.GetByPeriod("allananjos", DateTime.Now.Date, false);

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetAllDoneForTomorrow([FromServices] ITodoRepository repository) =>
              repository.GetByPeriod("allananjos", DateTime.Now.AddDays(1), true);


        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<TodoItem> GetAllUndoneForTomorrow([FromServices] ITodoRepository repository) =>
              repository.GetByPeriod("allananjos", DateTime.Now.AddDays(1), false);


        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone(
            [FromServices] TodoHandler handler,
            [FromBody] MarkTodoAsDoneCommand doneCommand)
        {
            doneCommand.User = "allananjos";
            return (GenericCommandResult)handler.Handler(doneCommand);
        }


        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone(
            [FromServices] TodoHandler handler,
            [FromBody] MarkTodoAsUndoneCommand doneCommand)
        {
            doneCommand.User = "allananjos";
            return (GenericCommandResult)handler.Handler(doneCommand);
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
       )
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Update(
            [FromServices] TodoHandler handler,
            [FromBody] UpdateTodoCommand command
        )
        {
            
             return (GenericCommandResult)handler.Handler(command);
        }
    }
}