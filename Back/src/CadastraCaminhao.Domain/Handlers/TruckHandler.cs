using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Handlers.Contracts;
using CadastraCaminhao.Domain.Repositories;
using Flunt.Notifications;
using System.Net;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Handlers
{
    public class TruckHandler : Notifiable,
            IHandler<TruckInsertCommand>,
            IHandler<TruckDeleteCommand>,
            IHandler<TruckUpdateCommand>
    {
        private readonly IContextRepository _contextRepository;
        private readonly ITruckRepository _truckRepository;

        public TruckHandler(IContextRepository contextRepository, ITruckRepository truckRepository)
        {
            _contextRepository = contextRepository;
            _truckRepository = truckRepository;
        }

        public async Task<ICommandResult> Handle(TruckInsertCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            Truck _entity = new Truck();
            _entity.Description = command.Description;
            _entity.Color = command.Color;
            _entity.Image = command.Image;
            _entity.Model = (EnumModel)command.Model;
            _entity.ModelYear = command.ModelYear;

            var _result = await _contextRepository.Add(_entity);

            if (!_result)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, _result);

            return new GenericCommandResult(true, HttpStatusCode.Created, _result);
        }

        public async Task<ICommandResult> Handle(TruckDeleteCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            var _verify = await _truckRepository.GetById(command.Id);

            if (_verify == null)
                return new GenericCommandResult(false, HttpStatusCode.NotFound, _verify);

            var _result = await _contextRepository.Delete(_verify);

            if (!_result)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, _result);

            return new GenericCommandResult(true, HttpStatusCode.OK, _result);
        }

        public async Task<ICommandResult> Handle(TruckUpdateCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            var _verify = await _truckRepository.GetById(command.Id);

            if (_verify == null)
                return new GenericCommandResult(false, HttpStatusCode.NotFound, _verify);

            Truck _entity = new Truck();
            _entity.Id = command.Id;
            _entity.Description = command.Description;
            _entity.Color = command.Color;
            _entity.Image = command.Image;
            _entity.Model = (EnumModel)command.Model;
            _entity.ModelYear = command.ModelYear;

            var _result = await _contextRepository.Update(_entity);

            if (!_result)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, _result);

            return new GenericCommandResult(true, HttpStatusCode.OK, _result);
        }
    }
}