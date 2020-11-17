using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            Ofertas = new HashSet<Ofertas>();
        }

        public int IdEmpresa { get; set; }
        public string Empresa { get; set; }

        public virtual ICollection<Ofertas> Ofertas { get; set; }
    }
}
