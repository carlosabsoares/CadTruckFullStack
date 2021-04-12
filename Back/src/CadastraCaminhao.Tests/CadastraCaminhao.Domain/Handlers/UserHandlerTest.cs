using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Handlers;
using CadastraCaminhao.Domain.Repositories;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Handlers
{
    public class UserHandlerTest
    {
        [Fact]
        public async Task TruckHandler_insert_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserInsertCommand userInsertCommand = new UserInsertCommand();

            userInsertCommand.Login = "login";
            userInsertCommand.Email = "email@email.com";
            userInsertCommand.Password = "password";
            userInsertCommand.Name = "Name";
            userInsertCommand.Role = "Role";

            mockContextRepository.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userInsertCommand);

            Assert.True(_return.Success);
            Assert.True((bool)_return.Data);
            Assert.Equal(HttpStatusCode.Created, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_insert_invalid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserInsertCommand userInsertCommand = new UserInsertCommand();

            userInsertCommand.Login = "login";
            userInsertCommand.Email = "email@email.com";
            userInsertCommand.Password = "password";
            userInsertCommand.Name = "Name";
            userInsertCommand.Role = "Role";

            mockContextRepository.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync(false);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userInsertCommand);

            Assert.False(_return.Success);
            Assert.False((bool)_return.Data);
            Assert.Equal(HttpStatusCode.BadRequest, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_delete_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserDeleteCommand userDeleteCommand = new UserDeleteCommand("b627435c-45ed-43e0-8969-e20ae10b4f21");

            User _user = new User()
            {
                Email = "email@email.com",
                Id = "b627435c-45ed-43e0-8969-e20ae10b4f21",
                Login = "login",
                Name = "name",
                Password = "senha",
                Role = "Administrator"
            };

            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            mockContextRepository.Setup(x => x.Delete(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userDeleteCommand);

            Assert.True(_return.Success);
            Assert.True((bool)_return.Data);
            Assert.Equal(HttpStatusCode.OK, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_delete_invalid_notsave()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserDeleteCommand userDeleteCommand = new UserDeleteCommand("b627435c-45ed-43e0-8969-e20ae10b4f21");

            User _user = new User()
            {
                Email = "email@email.com",
                Id = "b627435c-45ed-43e0-8969-e20ae10b4f21",
                Login = "login",
                Name = "name",
                Password = "senha",
                Role = "Administrator"
            };

            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            mockContextRepository.Setup(x => x.Delete(It.IsAny<User>())).ReturnsAsync(false);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userDeleteCommand);

            Assert.False(_return.Success);
            Assert.False((bool)_return.Data);
            Assert.Equal(HttpStatusCode.BadRequest, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_delete_invalid_notfound()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserDeleteCommand userDeleteCommand = new UserDeleteCommand("b627435c-45ed-43e0-8969-e20ae10b4f21");

            User _user = new User();
            _user = null;

            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            mockContextRepository.Setup(x => x.Delete(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userDeleteCommand);

            Assert.False(_return.Success);
            Assert.Null(_return.Data);
            Assert.Equal(HttpStatusCode.NotFound, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_validateAccess_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserValidateAccessCommand userValidateAccessCommand = new UserValidateAccessCommand();

            userValidateAccessCommand.Login = "login";
            userValidateAccessCommand.Password = "password";

            User _user = new User()
            {
                Email = "email@email.com",
                Id = "b627435c-45ed-43e0-8969-e20ae10b4f21",
                Login = "login",
                Name = "name",
                Password = "senha",
                Role = "Administrator"
            };

            mockUserRepository.Setup(x => x.GetValidate(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(_user);
            //mockContextRepository.Setup(x => x.Delete(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userValidateAccessCommand);

            Assert.True(_return.Success);
            Assert.Equal(HttpStatusCode.OK, _return.Code);
            Assert.NotNull(_return.Data);
        }

        [Fact]
        public async Task TruckHandler_validateAccess_invalid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserValidateAccessCommand userValidateAccessCommand = new UserValidateAccessCommand();

            userValidateAccessCommand.Login = "login";
            userValidateAccessCommand.Password = "password";

            User _user = new User();
            _user = null;

            mockUserRepository.Setup(x => x.GetValidate(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(_user);
            //mockContextRepository.Setup(x => x.Delete(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userValidateAccessCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.NotFound, _return.Code);
            Assert.Null(_return.Data);
        }

        [Fact]
        public async Task TruckHandler_update_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserUpdateCommand userUpdateCommand = new UserUpdateCommand();
            userUpdateCommand.Id = "04690063-39c2-4d86-8bf1-1ffbfb4503a2";
            userUpdateCommand.Login = "login";
            userUpdateCommand.Email = "email@email.com";
            userUpdateCommand.Password = "password";
            userUpdateCommand.Name = "Name";
            userUpdateCommand.Role = "Role";

            User _user = new User()
            {
                Email = "email@email.com",
                Id = "b627435c-45ed-43e0-8969-e20ae10b4f21",
                Login = "login",
                Name = "name",
                Password = "senha",
                Role = "Administrator"
            };

            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            mockContextRepository.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userUpdateCommand);

            Assert.True(_return.Success);
            Assert.Equal(HttpStatusCode.OK, _return.Code);
            Assert.True((bool)_return.Data);

            Assert.Equal("email@email.com", _user.Email);
            Assert.Equal("b627435c-45ed-43e0-8969-e20ae10b4f21", _user.Id);
            Assert.Equal("login", _user.Login);
            Assert.Equal("name", _user.Name);
            Assert.Equal("senha", _user.Password);
            Assert.Equal("Administrator", _user.Role);
        }

        [Fact]
        public async Task TruckHandler_update_invalid_notfound()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserUpdateCommand userUpdateCommand = new UserUpdateCommand();

            userUpdateCommand.Id = "04690063-39c2-4d86-8bf1-1ffbfb4503a2";
            userUpdateCommand.Login = "login";
            userUpdateCommand.Email = "email@email.com";
            userUpdateCommand.Password = "password";
            userUpdateCommand.Name = "Name";
            userUpdateCommand.Role = "Role";

            User _user = new User()
            {
                Email = "email@email.com",
                Id = "b627435c-45ed-43e0-8969-e20ae10b4f21",
                Login = "login",
                Name = "name",
                Password = "senha",
                Role = "Administrator"
            };

            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            mockContextRepository.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(false);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userUpdateCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.BadRequest, _return.Code);
            Assert.False((bool)_return.Data);
        }

        [Fact]
        public async Task TruckHandler_update_invalid_error_database()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            UserUpdateCommand userUpdateCommand = new UserUpdateCommand();

            userUpdateCommand.Id = "04690063-39c2-4d86-8bf1-1ffbfb4503a2";
            userUpdateCommand.Login = "login";
            userUpdateCommand.Email = "email@email.com";
            userUpdateCommand.Password = "password";
            userUpdateCommand.Name = "Name";
            userUpdateCommand.Role = "Role";

            User _user = new User();
            _user = null;

            mockUserRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_user);
            mockContextRepository.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(true);

            UserHandler _handler = new UserHandler(mockContextRepository.Object, mockUserRepository.Object);

            var _return = await _handler.Handle(userUpdateCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.NotFound, _return.Code);
            Assert.Null(_return.Data);
        }
    }
}