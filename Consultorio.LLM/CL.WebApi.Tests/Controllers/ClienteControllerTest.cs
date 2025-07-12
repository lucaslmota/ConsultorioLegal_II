using Cl.Core.Shared.ModelViews;
using CL_Manager.ManagerInterface;
using CL_WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace CL.WebApi.Tests.Controllers
{
    public class ClienteControllerTest
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClientesController> logger;
        private readonly ClientesController clientesController;

        public ClienteControllerTest()
        {
            clienteManager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClientesController>>();
            clientesController = new ClientesController(clienteManager,logger);
        }

        [Fact]
        public async Task Get_Ok()
        {
            clienteManager.GetClienteAsync().Returns(new List<ClienteView> { new ClienteView { ClienteNome = "Lucas" }});
            var resultado = (ObjectResult)await clientesController.Get();
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
