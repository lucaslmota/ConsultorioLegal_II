﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl.Core.Shared.ModelViews
{
    public class MedicoView
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CRM { get; set; }

        public ICollection<EspecialidadeView> Especialidades { get; set; }
    }
}
