﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class EnderecoView : ICloneable
    {
        public string CEP { get; set; }
        public EEstadoView Estado { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
