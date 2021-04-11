using CadastraCaminhao.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Handlers.Contracts;

namespace CadastraCaminhao.Api.Controllers
{
    [ApiController]
    [Route("v1/cadTruck")]
    public class TruckController : ControllerBase
    {
        /// <summary>Adiciona caminhão</summary>
        /// <returns>Retorna boolean indicando sucesso ou falha na operação</returns>
        [HttpPost("truck/create")]
        [Authorize]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<GenericCommandResult> PostTruck(
            [FromBody] TruckInsertCommand command,
            [FromServices] IHandler<TruckInsertCommand> handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        /// <summary>Altera caminhão</summary>
        /// <returns>Retorna boolean indicando sucesso ou falha na operação</returns>
        [HttpPut("truck/update")]
        [Authorize]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<GenericCommandResult> PutTruck(
            [FromBody] TruckUpdateCommand command,
            [FromServices] IHandler<TruckUpdateCommand> handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        /// <summary>Apaga caminhão</summary>
        /// <returns>Retorna boolean indicando sucesso ou falha na operação</returns>
        [HttpDelete("truck/delete")]
        [Authorize]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<GenericCommandResult> DeleteTruck(
            [FromQuery] string id,
            [FromServices] IHandler<TruckUpdateCommand> handler)
        {
            TruckUpdateCommand command = new TruckUpdateCommand();
            command.Id = id;
            
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}
