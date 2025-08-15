using Bogus;
using Bogus.Extensions.Brazil;
using Cl.Core.Shared.ModelViews;
using Cl.FakeData.EndrecoData;
using Cl.FakeData.TelefoneData;

namespace Cl.FakeData.ClienteData
{
    public class NovoClienteFaker : Faker<NewCliente>
    {
        public NovoClienteFaker()
        {
            RuleFor(p => p.ClienteNome, f => f.Person.FirstName);
            RuleFor(p => p.Sexo, f => f.PickRandom<ESexoView>());
            RuleFor(p => p.Documento, f => f.Person.Cpf());
            RuleFor(p => p.DtNascimento, f => f.Date.Past());
            RuleFor(p => p.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new NovoEndrecoFaker().Generate());
        }
    }
}
