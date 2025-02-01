using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using AutoMapper;

namespace CL_Manager.Mappings
{
    public class ClienteUpdateViewMappingProfile : Profile
    {
        public ClienteUpdateViewMappingProfile()
        {
            CreateMap<ClienteUpdateView, Cliente>()
                  .ForMember(destino => destino.UltimaAtualizacao, opcoes => opcoes.MapFrom(origem => DateTime.Now))
                  .ForMember(destino => destino.DtNascimento, opcoes => opcoes.MapFrom(origme => origme.DtNascimento.Date));
        }
    }
}
