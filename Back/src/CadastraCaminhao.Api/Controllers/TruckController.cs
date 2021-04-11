using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Handlers.Contracts;
using CadastraCaminhao.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            [FromServices] IHandler<TruckDeleteCommand> handler)
        {
            TruckDeleteCommand command = new TruckDeleteCommand();
            command.Id = id;

            return (GenericCommandResult)await handler.Handle(command);
        }

        /// <summary>Lista de todos caminhão</summary>
        /// <returns>Retorna boolean indicando sucesso ou falha na operação</returns>
        [HttpGet("truck/getall")]
        [Authorize]
        [ProducesResponseType(typeof(IList<Truck>), 200)]
        public async Task<IList<Truck>> GetAllTruck(
            [FromServices] ITruckRepository repository)
        {
            return await repository.GetAll();
        }

        /// <summary>Busca de um caminhão</summary>
        /// <returns>Retorna boolean indicando sucesso ou falha na operação</returns>
        [HttpGet("truck/getById")]
        [Authorize]
        [ProducesResponseType(typeof(Truck), 200)]
        public async Task<Truck> GetByIdTruck(
            [FromQuery] string id,
            [FromServices] ITruckRepository repository)
        {
            return await repository.GetById(id);
        }
    }
}