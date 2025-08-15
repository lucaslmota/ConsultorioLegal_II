using Cl.Core.Shared.ModelViews;
using Cl.FakeData.ClienteData;
using CL_Manager.ManagerInterface;
using CL_WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CL.WebApi.Tests.Controllers
{
    public class ClienteControllerTest
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClientesController> logger;
        private readonly ClientesController clientesController;
        private readonly ClienteView clienteView;
        private readonly List<ClienteView> listaClienteViews;
        private readonly NewCliente newCliente;

        public ClienteControllerTest()
        {
            clienteManager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClientesController>>();
            clientesController = new ClientesController(clienteManager,logger);

            clienteView = new ClienteViewFaker().Generate();
            listaClienteViews = new ClienteViewFaker().Generate(10);
            newCliente = new NovoClienteFaker().Generate();
        }

        [Fact]
        public async Task Get_Ok()
        {
            //Arrenje
            var controle = new List<ClienteView>();
            listaClienteViews.ForEach(p => controle.Add(p.CloneTipado()));

            //Act
            clienteManager.GetClienteAsync().Returns(listaClienteViews);

            //Assert
            var resultado = (ObjectResult)await clientesController.Get();
            resultado.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            //Arranje
            clienteManager.GetClienteAsync().Returns(new List<ClienteView>());

            //Act
            var resultado = (StatusCodeResult)await clientesController.Get();

            //Assert
            await clienteManager.Received().GetClienteAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            //Arranje
            clienteManager.GetIdClienteAsync(Arg.Any<int>()).Returns(clienteView.CloneTipado());

            //Act
            var resultado = (ObjectResult)await clientesController.GetId(clienteView.ClienteId);

            //Assert
            await clienteManager.Received().GetIdClienteAsync(Arg.Any<int>());
            resultado.Value.Should().BeEquivalentTo(clienteView);
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            //Arranje
            clienteManager.GetIdClienteAsync(Arg.Any<int>()).Returns(new ClienteView());

            //Act
            var resutado = (StatusCodeResult)await clientesController.GetId(1);

            //Assert
            await clienteManager.Received().GetIdClienteAsync(Arg.Any<int>());
            resutado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Ok()
        {
            //Arranje
            clienteManager.InsertClienteAsync(Arg.Any<NewCliente>()).Returns(clienteView.CloneTipado());
            //Act
            var resultado = (ObjectResult)await clientesController.InsertCliente(newCliente);

            //Assert
            await clienteManager.Received().InsertClienteAsync(Arg.Any<NewCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
            resultado.Value.Should().BeEquivalentTo(clienteView);
        }

        [Fact]
        public async Task Put_Ok()
        {
            //Arranje
            clienteManager.UpdadeteClienteAsync(Arg.Any<ClienteUpdateView>()).Returns(clienteView.CloneTipado());

            //Act
            var resultado = (ObjectResult)await clientesController.UpdateClente(new ClienteUpdateView());

            //Assert
            await clienteManager.Received().UpdadeteClienteAsync(Arg.Any<ClienteUpdateView>());
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(clienteView);

        }

        [Fact]
        public async Task Put_NotFound()
        {
            //Arrenje
            clienteManager.UpdadeteClienteAsync(Arg.Any<ClienteUpdateView>()).ReturnsNull();

            //Act
            var resultado = (StatusCodeResult)await clientesController.UpdateClente(new ClienteUpdateView());

            //Assert
            await clienteManager.Received().UpdadeteClienteAsync(Arg.Any<ClienteUpdateView>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            //Arranje
            clienteManager.DeleteClienteAsync(Arg.Any<int>()).Returns(clienteView);

            //Act
            var resultado = (StatusCodeResult)await clientesController.DeleteCliente(clienteView.ClienteId);

            //Asserte

            await clienteManager.Received().DeleteClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);

        }

        [Fact]
        public async Task Delete_NotFound()
        {
            //Arranje
            clienteManager.DeleteClienteAsync(Arg.Any<int>()).ReturnsNull();
            //Act
            var resultado = (StatusCodeResult)await clientesController.DeleteCliente(1);
            //Assert
            await clienteManager.Received().DeleteClienteAsync(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);

        }
    }
}
