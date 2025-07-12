﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class ClienteView : ICloneable
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DtNascimento { get; set; }
        public ESexoView Sexo { get; set; }
        public ICollection<TelefoneView> Telefones { get; set; }

        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        public EnderecoView Endereco { get; set; }

        public object Clone()
        {
            var cliente = (ClienteView)MemberwiseClone();
            cliente.Endereco = (EnderecoView)cliente.Endereco.Clone();
            var telefones = new List<TelefoneView>();
            cliente.Telefones.ToList().ForEach(p => telefones.Add((TelefoneView)p.Clone()));
            cliente.Telefones = telefones;
            return cliente;
        }

        public ClienteView CloneTipado()
        {
            return (ClienteView)Clone();
        }
    }
}
