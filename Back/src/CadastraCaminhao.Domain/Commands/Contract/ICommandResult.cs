using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        public HttpStatusCode Code { get; set; }
        object Data { get; set; }
    }
}
