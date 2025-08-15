using Bogus;
using Cl.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.TelefoneData
{
    public class TelefoneViewFaker : Faker<TelefoneView>
    {
        public TelefoneViewFaker()
        {
            RuleFor(p => p.ClienteId, f => f.Random.Number(1, 10));
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
