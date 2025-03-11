using AutoMapper;
using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Mappings
{
    public class ClienteViewMappingProfile : Profile
    {
        public ClienteViewMappingProfile()
        {
            CreateMap<ClienteView, Cliente>()
                .ForMember(destino => destino.Criacao, opcoes => opcoes.MapFrom(origem => DateTime.Now))
                .ForMember(destino => destino.DtNascimento, opcoes => opcoes.MapFrom(origme => origme.DtNascimento.Date));

            CreateMap<EnderecoView, Endereco>();
            CreateMap<TelefoneView, Telefone>();
        }
    }
}
