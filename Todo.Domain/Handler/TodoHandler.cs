using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handler.Contracts;
using Todo.Domain.Repository;

namespace Todo.Domain.Handler
{
    public class TodoHandler : Notifiable, 
    IHandler<CreateTodoCommand>, 
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handler(CreateTodoCommand command)
        {
            command.Validate();
            if(command.Invalid)
                 return new GenericCommandResult(false, "Ops, parace que sua tarefa esta errada", command.Notifications);

            var todo = new TodoItem(command.Title, command.Date, command.User);

            _todoRepository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva com sucesso", todo);
        }

        public ICommandResult Handler(UpdateTodoCommand command)
        {
            
            command.Validate();
            if(command.Invalid)
                 return new GenericCommandResult(false, "Ops, parace que sua tarefa esta errada", command.Notifications);

            var todo = _todoRepository.GetById(command.Id,command.User);

            todo.UpdateTitle(command.Title);

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa atualizada com Sucesso!!!", todo);
        }

        public ICommandResult Handler(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if(command.Invalid)
                 return new GenericCommandResult(false, "Ops, parace que sua tarefa esta errada", command.Notifications);

            var todo = _todoRepository.GetById(command.Id,command.User);

            todo.MarkAsDone();

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa marcada como Concluida", todo);
        }

        public ICommandResult Handler(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if(command.Invalid)
                 return new GenericCommandResult(false, "Ops, parace que sua tarefa esta errada", command.Notifications);

            var todo = _todoRepository.GetById(command.Id,command.User);

            todo.MarkAsUndone();

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa marcada incompleta", todo);
        }
    }
}