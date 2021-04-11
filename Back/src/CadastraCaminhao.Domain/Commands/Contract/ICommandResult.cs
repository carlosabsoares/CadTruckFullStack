using System.Net;

namespace CadastraCaminhao.Domain.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        public HttpStatusCode Code { get; set; }
        object Data { get; set; }
    }
}