using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Commands
{
    public class GenericCommandResult: ICommandResult
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
