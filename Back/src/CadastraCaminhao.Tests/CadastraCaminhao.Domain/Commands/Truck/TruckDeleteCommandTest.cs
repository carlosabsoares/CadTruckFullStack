using System;
using CadastraCaminhao.Domain.Commands;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Commands.Truck
{
    public class TruckDeleteCommandTest
    {
        private readonly string id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd";

        [Fact]
        public void TruckDeleteCommand_valid()
        {
            TruckDeleteCommand _command = new TruckDeleteCommand(id);

            _command.Validate();

            Assert.True(_command.Valid);
            Assert.False(_command.Invalid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("1234")]
        [InlineData("5cae6e12-02a1-4e68-82ec-f2834d3597c4cc")]
        public void TruckDeleteCommand_invalid(string param)
        {
            TruckDeleteCommand _command = new TruckDeleteCommand(param);

            _command.Validate();

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);
        }
    }
}
