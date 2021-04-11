using CadastraCaminhao.Domain.Commands;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Handlers;
using CadastraCaminhao.Domain.Repositories;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CadastraCaminhao.Tests.CadastraCaminhao.Domain.Handlers
{
    public class TruckHandlerTest
    {
        [Fact]
        public async Task TruckHandler_insert_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckInsertCommand trunlInsertCommand = new TruckInsertCommand();

            trunlInsertCommand.Color = "Blue";
            trunlInsertCommand.Image = "img.jpg";
            trunlInsertCommand.Model = 1;
            trunlInsertCommand.ModelYear = DateTime.Now.Year;

            mockContextRepository.Setup(x => x.Add(It.IsAny<Truck>())).ReturnsAsync(true);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunlInsertCommand);

            Assert.True(_return.Success);
            Assert.True((bool)_return.Data);
            Assert.Equal(HttpStatusCode.Created, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_insert_invalid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckInsertCommand trunlInsertCommand = new TruckInsertCommand();

            trunlInsertCommand.Color = "Blue";
            trunlInsertCommand.Image = "img.jpg";
            trunlInsertCommand.Model = 1;
            trunlInsertCommand.ModelYear = DateTime.Now.Year;

            mockContextRepository.Setup(x => x.Add(It.IsAny<Truck>())).ReturnsAsync(false);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunlInsertCommand);

            Assert.False(_return.Success);
            Assert.False((bool)_return.Data);
            Assert.Equal(HttpStatusCode.BadRequest, _return.Code);
        }

        [Fact]
        public async Task TruckHandler_Update_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckUpdateCommand trunlUpdateCommand = new TruckUpdateCommand();

            trunlUpdateCommand.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            trunlUpdateCommand.Color = "Blue";
            trunlUpdateCommand.Image = "img.jpg";
            trunlUpdateCommand.Model = 1;
            trunlUpdateCommand.ModelYear = DateTime.Now.Year;

            Truck _truck = new Truck();
            _truck.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            _truck.Color = "Red";
            _truck.Image = "img1.jpg";
            _truck.Model = EnumModel.FH;
            _truck.ModelYear = DateTime.Now.Year;

            mockTruckRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_truck);
            mockContextRepository.Setup(x => x.Update(It.IsAny<Truck>())).ReturnsAsync(true);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunlUpdateCommand);

            Assert.True(_return.Success);
            Assert.Equal(HttpStatusCode.OK, _return.Code);
            Assert.True((bool)_return.Data);
        }

        [Fact]
        public async Task TruckHandler_Update_invalid_no_data_found()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckUpdateCommand trunlUpdateCommand = new TruckUpdateCommand();

            trunlUpdateCommand.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            trunlUpdateCommand.Color = "Blue";
            trunlUpdateCommand.Image = "img.jpg";
            trunlUpdateCommand.Model = 1;
            trunlUpdateCommand.ModelYear = DateTime.Now.Year;

            Truck _truck = new Truck();
            _truck = null;

            mockTruckRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_truck);
            mockContextRepository.Setup(x => x.Update(It.IsAny<Truck>())).ReturnsAsync(true);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunlUpdateCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.NotFound, _return.Code);
            Assert.Null(_return.Data);
        }

        [Fact]
        public async Task TruckHandler_Update_invalid_update_error()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckUpdateCommand trunlUpdateCommand = new TruckUpdateCommand();

            trunlUpdateCommand.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            trunlUpdateCommand.Color = "Blue";
            trunlUpdateCommand.Image = "img.jpg";
            trunlUpdateCommand.Model = 1;
            trunlUpdateCommand.ModelYear = DateTime.Now.Year;

            Truck _truck = new Truck();
            _truck.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            _truck.Color = "Red";
            _truck.Image = "img1.jpg";
            _truck.Model = EnumModel.FH;
            _truck.ModelYear = DateTime.Now.Year;

            mockTruckRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_truck);
            mockContextRepository.Setup(x => x.Update(It.IsAny<Truck>())).ReturnsAsync(false);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunlUpdateCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.BadRequest, _return.Code);
            Assert.False((bool)_return.Data);
        }

        [Fact]
        public async Task TruckHandler_Delete_valid()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckDeleteCommand trunkDeleteCommand = new TruckDeleteCommand();

            trunkDeleteCommand.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";

            Truck _truck = new Truck();
            _truck.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            _truck.Color = "Red";
            _truck.Image = "img1.jpg";
            _truck.Model = EnumModel.FH;
            _truck.ModelYear = DateTime.Now.Year;

            mockTruckRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_truck);
            mockContextRepository.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunkDeleteCommand);

            Assert.True(_return.Success);
            Assert.Equal(HttpStatusCode.OK, _return.Code);
            Assert.True((bool)_return.Data);
        }

        [Fact]
        public async Task TruckHandler_Delete_invalid_no_data_found()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckDeleteCommand trunkDeleteCommand = new TruckDeleteCommand();

            trunkDeleteCommand.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";

            Truck _truck = new Truck();
            _truck = null;

            mockTruckRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_truck);
            mockContextRepository.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunkDeleteCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.NotFound, _return.Code);
            Assert.Null(_return.Data);
        }

        [Fact]
        public async Task TruckHandler_Delete_invalid_no_delete_found()
        {
            var mockContextRepository = new Mock<IContextRepository>();
            var mockTruckRepository = new Mock<ITruckRepository>();

            TruckDeleteCommand trunkDeleteCommand = new TruckDeleteCommand();

            trunkDeleteCommand.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";

            Truck _truck = new Truck();
            _truck.Id = "45f65a56-e30d-4a61-8e40-e14a4cc35ce9";
            _truck.Color = "Red";
            _truck.Image = "img1.jpg";
            _truck.Model = EnumModel.FH;
            _truck.ModelYear = DateTime.Now.Year;

            mockTruckRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(_truck);
            mockContextRepository.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(false);

            TruckHandler _handler = new TruckHandler(mockContextRepository.Object, mockTruckRepository.Object);

            var _return = await _handler.Handle(trunkDeleteCommand);

            Assert.False(_return.Success);
            Assert.Equal(HttpStatusCode.BadRequest, _return.Code);
            Assert.False((bool)_return.Data);
        }
    }
}