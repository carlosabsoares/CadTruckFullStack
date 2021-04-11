using CadastraCaminhao.Domain.Commands;
using System;
using System.Collections.Generic;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Commands.Truck
{
    public class TruckInsertCommandTest
    {
        [Fact]
        public void TruckInsertCommand_valid()
        {
            TruckInsertCommand _command = new TruckInsertCommand();

            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = DateTime.Now.Year;
            _command.Description = "description";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.True(_command.Valid);
            Assert.False(_command.Invalid);

            Assert.NotEmpty(_command.Color);
            Assert.NotEmpty(_command.Image);
            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 0);
        }

        [Fact]
        public void TruckInsertCommand_invalid_Model_diferent_FH_FM()
        {
            TruckInsertCommand _command = new TruckInsertCommand();

            _command.Model = 3;
            _command.ModelYear = DateTime.Now.Year;
            _command.Description = "description";

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
        public void TruckInsertCommand_invalid_ModelYear_diferent_current_and_after_year_up()
        {
            TruckInsertCommand _command = new TruckInsertCommand();

            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = (DateTime.Now.Year + 2);
            _command.Description = "description";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("The model year must be the current year or the year after.", _notification[0].Message);
        }

        [Fact]
        public void TruckInsertCommand_invalid_ModelYear_diferent_current_and_after_year_down()
        {
            TruckInsertCommand _command = new TruckInsertCommand();

            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = (DateTime.Now.Year - 2);
            _command.Description = "description";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("The model year must be the current year or the year after.", _notification[0].Message);
        }

        [Fact]
        public void TruckInsertCommand_invalid_Description_null()
        {
            TruckInsertCommand _command = new TruckInsertCommand();

            _command.Model = 1;
            _command.Color = "blue";
            _command.Image = "img1.png";
            _command.ModelYear = (DateTime.Now.Year);
            _command.Description = "";

            _command.Validate();
            var _notification = (List<Flunt.Notifications.Notification>)_command.Notifications;

            Assert.False(_command.Valid);
            Assert.True(_command.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)_command.Notifications).Count == 1);
            Assert.Equal("Description not be null.", _notification[0].Message);
        }
    }
}