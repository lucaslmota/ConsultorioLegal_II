using Bogus;
using Bogus.Extensions.Brazil;
using Cl.Core.Shared.ModelViews;
using Cl.FakeData.EndrecoData;
using Cl.FakeData.TelefoneData;

namespace Cl.FakeData.ClienteData
{
    public class ClienteViewFaker : Faker<ClienteView>
    {
        public ClienteViewFaker()
        {
        
            RuleFor(p => p.ClienteId, f => f.Random.Int(1, 1000));
            RuleFor(p => p.ClienteNome, f => f.Person.FirstName);
            RuleFor(p => p.Sexo, f => f.PickRandom<ESexoView>());
            RuleFor(p => p.Documento, f => f.Person.Cpf());
            RuleFor(p => p.Criacao, f => f.Date.Past());
            RuleFor(p => p.UltimaAtualizacao, f => f.Date.Past());
            RuleFor(p => p.DtNascimento, f => f.Date.Past());
            RuleFor(p => p.Telefones, f => new TelefoneViewFaker().Generate(3));
            RuleFor(p => p.Endereco, _ => new EnderecoViewFaker().Generate());
        }
    }
}
