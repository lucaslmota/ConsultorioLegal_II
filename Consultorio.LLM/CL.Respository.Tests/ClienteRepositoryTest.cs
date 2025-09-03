using Cl.FakeData.ClienteData;
using Cl.FakeData.TelefoneData;
using CL_Core.Domain;
using CL_Data.Context;
using CL_Data.Repository;
using CL_Manager.Interfaces;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Respository.Tests
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ClContext _context;

        private readonly Cliente Cliente;
        private ClienteFaker clienteFaker;

        public ClienteRepositoryTest()
        {
            //simular o comando de conexão com o banco de dados
            var optionsBuilder = new DbContextOptionsBuilder<ClContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");

            _context = new ClContext(optionsBuilder.Options);
            _clienteRepository = new ClienteRepsitory(_context);

            clienteFaker = new ClienteFaker();
            Cliente = clienteFaker.Generate();
        }

        //Esse método garante a geração de dados para uma simulção de inserção, que importante para os testes
        //do repository.
        private async Task<List<Cliente>> InserirRegistros()
        {
            var clientes = clienteFaker.Generate(100);
            foreach (var cliente in clientes)
            {
                cliente.ClienteId = 0; // Garantir que o ID seja 0 para que o banco de dados gere um novo ID
                await _context.Clientes.AddAsync(cliente);
            }
            await _context.SaveChangesAsync();
            return clientes;
        }

        [Fact]
        public async Task GetClientesAsync_ComRetorno()
        {
            var registros = await InserirRegistros();
            var resultado = await _clienteRepository.GetClienteAsync();

            resultado.Should().HaveCount(registros.Count);
            resultado.First().Endereco.Should().NotBeNull();
            resultado.First().Telefones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            var resultado = await _clienteRepository.GetClienteAsync();
            resultado.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClienteAsync_Encontrado()
        {
            var registros = await InserirRegistros();
            var resultado = await _clienteRepository.GetIdClienteAsync(registros.First().ClienteId);
            resultado.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncontrado()
        {
            var resultado = await _clienteRepository.GetIdClienteAsync(1);
            resultado.Should().BeNull();
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            var resultado = await _clienteRepository.InsertClienteAsync(Cliente);
            resultado.Should().BeEquivalentTo(Cliente);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            var registros = await InserirRegistros();
            var clienteAlterado = clienteFaker.Generate();
            clienteAlterado.ClienteId = registros.First().ClienteId;
            var resultado = await _clienteRepository.UpdadeteClienteAsync(clienteAlterado);
            resultado.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_AdicionaTelefone()
        {
            var registros = await InserirRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.ClienteId).Generate());
            var retorno = await _clienteRepository.UpdadeteClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_RemoveTelefone() 
        {
            var resgistros = await InserirRegistros();
            var clienteAlterado = resgistros.First();
            clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());
            var retorno = await _clienteRepository.UpdadeteClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            var retorno = await _clienteRepository.UpdadeteClienteAsync(Cliente);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            var registros = await InserirRegistros();
            var retorno = await _clienteRepository.DeleteClienteAsync(registros.First().ClienteId);
            retorno.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {
            var retorno = await _clienteRepository.DeleteClienteAsync(1);
            retorno.Should().BeNull();
        }
        //O uso de IDisposable aqui serve para garantir o descarte adequado do contexto do banco de dados
        //após cada teste, mantendo o ambiente limpo e eficiente.16:20
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
