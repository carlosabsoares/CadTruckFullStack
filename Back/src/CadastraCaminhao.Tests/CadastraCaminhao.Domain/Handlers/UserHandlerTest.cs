using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Handlers;
using CadastraCaminhao.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        public async Task TruckHandler_delete_invalid_notfound()
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

    }
}
