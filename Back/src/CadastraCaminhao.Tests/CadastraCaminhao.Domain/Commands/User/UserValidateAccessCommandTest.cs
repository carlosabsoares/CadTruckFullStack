using CadastraCaminhao.Domain.Commands;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Commands.User
{
    public class UserValidateAccessCommandTest
    {
        [Fact]
        public void UserValidateAccessCommand_valid()
        {
            UserValidateAccessCommand _command = new UserValidateAccessCommand();
            _command.Login = "login";
            _command.Password = "password";

            _command.Validate();

            Assert.True(_command.Valid);
            Assert.False(_command.Invalid);
        }

        [Theory]
        [InlineData("login", "")]
        [InlineData("login", null)]
        [InlineData("", "password")]
        [InlineData(null, "password")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void UserValidateAccessCommand_invalid(string param1, string param2)
        {
            UserValidateAccessCommand _command = new UserValidateAccessCommand();
            _command.Login = param1;
            _command.Password = param2;

            _command.Validate();

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);
        }
    }
}