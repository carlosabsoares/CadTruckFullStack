using CadastraCaminhao.Domain.Commands;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Commands.User
{
    public class UserDeleteCommandTest
    {
        private readonly string id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd";

        [Fact]
        public void UserDeleteCommand_valid()
        {
            UserDeleteCommand _command = new UserDeleteCommand(id);

            _command.Validate();

            Assert.True(_command.Valid);
            Assert.False(_command.Invalid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("1234")]
        [InlineData("5cae6e12-02a1-4e68-82ec-f2834d3597c4cc")]
        public void UserDeleteCommand_invalid(string param)
        {
            UserDeleteCommand _command = new UserDeleteCommand(param);

            _command.Validate();

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);
        }
    }
}