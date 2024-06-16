using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {

        public GenericCommandResult(){}
        public GenericCommandResult(bool success, string msg, object data)
        {
            Success = success;
            Msg = msg;
            Data = data;
        }

        public bool Success { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }

    }
}