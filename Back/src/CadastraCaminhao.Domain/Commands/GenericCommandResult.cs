using System.Net;

namespace CadastraCaminhao.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public HttpStatusCode Code { get; set; }
        public object Data { get; set; }

        public GenericCommandResult(bool success, HttpStatusCode code, object data)
        {
            Success = success;
            Code = code;
            Data = data;
        }
    }
}