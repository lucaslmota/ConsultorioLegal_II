using Bogus;
using Cl.Core.Shared.ModelViews;
using Cl.FakeData.EndrecoData;
using Cl.FakeData.TelefoneData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.ClienteData
{
    public class AlteraClienteFaker : Faker<ClienteUpdateView>
    {
        public AlteraClienteFaker()
        {
            RuleFor(p => p.ClienteId, f => new Faker().Random.Number(1,100));
            RuleFor(p => p.ClienteNome, f => f.Person.FullName);
            RuleFor(p => p.Sexo, f => f.PickRandom<ESexoView>());
            RuleFor(p => p.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new NovoEndrecoFaker().Generate());
        }
    }
}
