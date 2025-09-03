using Bogus;
using CL_Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.FakeData.TelefoneData
{
    public class TelefoneFaker : Faker<Telefone>
    {
        public TelefoneFaker(int clientId)
        {
            RuleFor(o => o.ClienteId, _ => clientId);
            RuleFor(o => o.Numero, f => f.Person.Phone);
        }
    }
}
