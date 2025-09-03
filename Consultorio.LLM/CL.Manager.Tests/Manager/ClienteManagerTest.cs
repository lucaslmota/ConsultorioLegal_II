using AutoMapper;
using Cl.Core.Shared.ModelViews;
using Cl.FakeData.ClienteData;
using CL_Core.Domain;
using CL_Manager.Implementation;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;
using CL_Manager.Mappings;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CL.Manager.Tests.Manager
{
    public class ClienteManagerTest
    {
        private readonly IClienteRepository repository;

        private readonly ILogger<ClienteManager> logger;

        private readonly IMapper mapper;

        private readonly IClienteManager clienteManager;

        private readonly Cliente Cliente;

        private readonly NewCliente newCliente;

        private readonly ClienteUpdateView clienteUpdateView;

        private readonly ClienteFaker clienteFaker;

        private readonly NovoClienteFaker novoClienteFaker;

        private readonly AlteraClienteFaker alteraClienteFaker;

        public ClienteManagerTest()
        {
            repository = Substitute.For<IClienteRepository>();
            logger = Substitute.For<ILogger<ClienteManager>>();
            mapper = new MapperConfiguration(p => p.AddProfile<ClienteViewMappingProfile>()).CreateMapper();
            clienteManager = new ClienteManager(repository, mapper, logger);
            clienteFaker = new ClienteFaker();
            novoClienteFaker = new NovoClienteFaker();
            alteraClienteFaker = new AlteraClienteFaker();

            Cliente = mapper.Map<Cliente>(clienteFaker.Generate());
            newCliente = novoClienteFaker.Generate();
            clienteUpdateView = alteraClienteFaker.Generate();
        }

        [Fact]
        public async Task GetClientesAsync_Sucesso()
        {
            // Arrange
            var listaClientes = clienteFaker.Generate(5);
            repository.GetClienteAsync().Returns(listaClientes);

            // Act
            var controle = mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(listaClientes);
            var retorno = await clienteManager.GetClienteAsync();

            // Assert
            await repository.Received().GetClienteAsync();
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            //Arrange
            repository.GetClienteAsync().Returns(new List<Cliente>());

            //Act
            var retorno = await clienteManager.GetClienteAsync();

            //Assert
            await repository.Received().GetClienteAsync();
            retorno.Should().BeEquivalentTo(new List<Cliente>());
        }

        [Fact]
        public async Task GetClienteAsync_Sucesso()
        {
            repository.GetIdClienteAsync(Arg.Any<int>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.GetIdClienteAsync(Cliente.ClienteId);

            await repository.Received().GetIdClienteAsync(Cliente.ClienteId);
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncontrado()
        {
            repository.GetIdClienteAsync(Arg.Any<int>()).Returns(new Cliente());
            var controle = mapper.Map<ClienteView>(new Cliente());
            var retorno = await clienteManager.GetIdClienteAsync(1);

            await repository.Received().GetIdClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            repository.InsertClienteAsync(Arg.Any<Cliente>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.InsertClienteAsync(newCliente);

            await repository.Received().InsertClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            repository.UpdadeteClienteAsync(Arg.Any<Cliente>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.UpdadeteClienteAsync(clienteUpdateView);

            await repository.Received().UpdadeteClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            repository.UpdadeteClienteAsync(Arg.Any<Cliente>()).ReturnsNull();

            var retorno = await clienteManager.UpdadeteClienteAsync(clienteUpdateView);

            await repository.Received().UpdadeteClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            repository.DeleteClienteAsync(Arg.Any<int>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.DeleteClienteAsync(Cliente.ClienteId);

            await repository.Received().DeleteClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {
            repository.DeleteClienteAsync(Arg.Any<int>()).ReturnsNull();

            var retorno = await clienteManager.DeleteClienteAsync(1);

            await repository.Received().DeleteClienteAsync(Arg.Any<int>());
            retorno.Should().BeNull();
        }

    }
}
