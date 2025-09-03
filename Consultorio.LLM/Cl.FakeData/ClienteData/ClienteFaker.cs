using Bogus;
using Bogus.Extensions.Brazil;
using Cl.Core.Shared.ModelViews;
using Cl.FakeData.EndrecoData;
using Cl.FakeData.TelefoneData;
using CL_Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.ClienteData
{
    public class ClienteFaker : Faker<Cliente>
    {
        public ClienteFaker()
        {
            var id = new Faker().Random.Number(1, 999999);
            RuleFor(o => o.ClienteId, _ => id);
            RuleFor(o => o.ClienteNome, f => f.Person.FullName);
            RuleFor(o => o.Sexo, f => f.PickRandom<Sexo>());
            RuleFor(o => o.Documento, f => f.Person.Cpf());
            RuleFor(o => o.Criacao, f => f.Date.Past());
            RuleFor(o => o.UltimaAtualizacao, f => f.Date.Past());
            RuleFor(o => o.Telefones, f => new TelefoneFaker(id).Generate(3));
            RuleFor(o => o.Endereco, _ => new EnderecoFaker(id).Generate());
        }
    }
}
