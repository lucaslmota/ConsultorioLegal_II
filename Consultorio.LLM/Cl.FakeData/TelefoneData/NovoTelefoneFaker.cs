using Bogus;
using Cl.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.TelefoneData
{
    public class NovoTelefoneFaker : Faker<NewTelefone>
    {
        public NovoTelefoneFaker()
        {
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
