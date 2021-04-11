using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Commands;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Commands.User
{
    public class UserInsertCommandTest
    {
        [Fact]
        public void UserInsertCommand_valid()
        {
            UserInsertCommand _command = new UserInsertCommand();

            _command.Email = "email@email.com";
            _command.Login = "Login";
            _command.Name = "carlos";
            _command.Password = "password";
            _command.Role = "role";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.True(_command.Valid);
            Assert.False(_command.Invalid);


            Assert.NotEmpty(_command.Email);
            Assert.NotEmpty(_command.Login);
            Assert.NotEmpty(_command.Name);
            Assert.NotEmpty(_command.Password);
            Assert.NotEmpty(_command.Role);
            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 0);
        }

        [Fact]
        public void UserInsertCommand_invalid_email_invalid()
        {
            UserInsertCommand _command = new UserInsertCommand();

            _command.Email = "email.email.com";
            _command.Login = "Login";
            _command.Name = "carlos";
            _command.Password = "password";
            _command.Role = "role";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);


            Assert.NotEmpty(_command.Email);
            Assert.NotEmpty(_command.Login);
            Assert.NotEmpty(_command.Name);
            Assert.NotEmpty(_command.Password);
            Assert.NotEmpty(_command.Role);
            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("Email not valid.", _notification[0].Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void UserInsertCommand_invalid_login_invalid(string param)
        {
            UserInsertCommand _command = new UserInsertCommand();

            _command.Email = "email@email.com";
            _command.Login = "Login";
            _command.Name = "carlos";
            _command.Password = "password";
            _command.Role = "role";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);


            Assert.NotEmpty(_command.Email);
            Assert.NotEmpty(_command.Login);
            Assert.NotEmpty(_command.Name);
            Assert.NotEmpty(_command.Password);
            Assert.NotEmpty(_command.Role);
            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("Email not valid.", _notification[0].Message);
        }

    }
}
