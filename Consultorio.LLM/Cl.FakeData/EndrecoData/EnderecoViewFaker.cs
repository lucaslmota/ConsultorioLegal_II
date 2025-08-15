using Bogus;
using Cl.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.EndrecoData
{
    public class EnderecoViewFaker : Faker<EnderecoView>
    {
        public EnderecoViewFaker()
        {
            RuleFor(p => p.Numero, f => f.Address.BuildingNumber());
            RuleFor(p => p.CEP, f => f.Address.ZipCode().Replace("-", ""));
            RuleFor(p => p.Cidade, f => f.Address.City());
            RuleFor(p => p.Estado, f => f.PickRandom<EEstadoView>());
            RuleFor(p => p.Logradouro, f => f.Address.StreetName());
            RuleFor(p => p.Complemento, f => f.Lorem.Sentence(20));
        }
    }
}
