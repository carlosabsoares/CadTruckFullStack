using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Handlers.Contracts;
using CadastraCaminhao.Domain.Repositories;
using CadastraCaminhao.Domain.Services;
using Flunt.Notifications;
using System.Net;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Handlers
{
    public class UserHandler : Notifiable,
             IHandler<UserInsertCommand>,
             IHandler<UserDeleteCommand>,
             IHandler<UserUpdateCommand>,
             IHandler<UserValidateAccessCommand>
    {
        private readonly IContextRepository _contextRepository;
        private readonly IUserRepository _userRepository;

        public UserHandler(IContextRepository contextRepository, IUserRepository userRepository)
        {
            _contextRepository = contextRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(UserInsertCommand command)
        {
            //FFV
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            User _entity = new User();
            _entity.Login = command.Login;
            _entity.Password = command.Password;
            _entity.Name = command.Name;
            _entity.Email = command.Email;
            _entity.Role = command.Role.ToString();

            var _result = await _contextRepository.Add(_entity);

            //retorna o resultado
            if (!_result)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, _result);

            return new GenericCommandResult(true, HttpStatusCode.Created, _result);
        }

        public async Task<ICommandResult> Handle(UserDeleteCommand command)
        {
            //FFV
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            var _verify = await _userRepository.GetById(command.Id);

            if (_verify == null)
                return new GenericCommandResult(false, HttpStatusCode.NotFound, _verify);

            User _entity = new User();
            _entity.Id = command.Id;

            var _result = await _contextRepository.Delete(_entity);

            //retorna o resultado
            if (!_result)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, _result);

            return new GenericCommandResult(true, HttpStatusCode.OK, _result);
        }

        public async Task<ICommandResult> Handle(UserUpdateCommand command)
        {
            //FFV
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            var _verify = await _userRepository.GetById(command.Id);

            if (_verify == null)
                return new GenericCommandResult(false, HttpStatusCode.NotFound, _verify);

            User _entity = new User();
            _entity.Id = command.Id;
            _entity.Login = command.Login;
            _entity.Password = command.Password;
            _entity.Name = command.Name;
            _entity.Role = command.Role.ToString();

            var _result = await _contextRepository.Update(_entity);

            //retorna o resultado
            if (!_result)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, _result);

            return new GenericCommandResult(true, HttpStatusCode.OK, _result);
        }

        public async Task<ICommandResult> Handle(UserValidateAccessCommand command)
        {
            //FFV
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, HttpStatusCode.BadRequest, command.Notifications);

            var _result = await _userRepository.GetValidate(command.Login, command.Password);

            //retorna o resultado
            if (_result == null)
                return new GenericCommandResult(false, HttpStatusCode.NotFound, _result);

            var token = TokenService.GenerateToken(_result);

            return new GenericCommandResult(true, HttpStatusCode.OK, new { _result, token });
        }
    }
}