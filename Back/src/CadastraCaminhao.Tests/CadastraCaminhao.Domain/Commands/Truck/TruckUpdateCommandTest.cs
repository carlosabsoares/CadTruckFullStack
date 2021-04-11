using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Commands;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Commands.Truck
{
    public class TruckUpdateCommandTest
    {
        [Fact]
        public void TruckUpdateCommand_valid()
        {
            TruckUpdateCommand _command = new TruckUpdateCommand();

            _command.Id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd";
            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = DateTime.Now.Year;

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.True(_command.Valid);
            Assert.False(_command.Invalid);


            Assert.NotEmpty(_command.Color);
            Assert.NotEmpty(_command.Image);
            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 0);
        }

        [Fact]
        public void TruckUpdateCommand_invalid_Id()
        {
            TruckUpdateCommand _command = new TruckUpdateCommand();

            _command.Id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd57";
            _command.Model = 1;
            _command.ModelYear = DateTime.Now.Year;

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.Null(_command.Color);
            Assert.Null(_command.Image);
            Assert.NotNull(_command.ModelYear);
            Assert.NotNull(_command.Model);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("This Id is not a valid guid.", _notification[0].Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TruckUpdateCommand_invalid_Id_Null_or_empty(string param)
        {
            TruckUpdateCommand _command = new TruckUpdateCommand();

            _command.Id = param;
            _command.Model = 1;
            _command.ModelYear = DateTime.Now.Year;

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.Null(_command.Color);
            Assert.Null(_command.Image);
            Assert.NotNull(_command.ModelYear);
            Assert.NotNull(_command.Model);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 2);
            Assert.Equal("Id not be null.", _notification[0].Message);
            Assert.Equal("This Id is not a valid guid.", _notification[1].Message);
        }

        [Fact]
        public void TruckUpdateCommand_invalid_Model_diferent_FH_FM()
        {
            TruckUpdateCommand _command = new TruckUpdateCommand();

            _command.Id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd";
            _command.Model = 3;
            _command.ModelYear = DateTime.Now.Year;

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.Null(_command.Color);
            Assert.Null(_command.Image);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("Model not valid.", _notification[0].Message);
        }

        [Fact]
        public void TruckUpdateCommand_invalid_ModelYear_diferent_current_and_after_year_up()
        {
            TruckUpdateCommand _command = new TruckUpdateCommand();

            _command.Id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd";
            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = (DateTime.Now.Year + 2);

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("The model year must be the current year or the year after.", _notification[0].Message);
        }

        [Fact]
        public void TruckUpdateCommand_invalid_ModelYear_diferent_current_and_after_year_down()
        {
            TruckUpdateCommand _command = new TruckUpdateCommand();

            _command.Id = "5cae6e12-02a1-4e68-82ec-f34d3597c4cd";
            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = (DateTime.Now.Year - 2);

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("The model year must be the current year or the year after.", _notification[0].Message);
        }
    }
}
