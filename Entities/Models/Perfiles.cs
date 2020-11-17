using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Perfiles
    {
        public Perfiles()
        {
            Ofertas = new HashSet<Ofertas>();
        }

        public int IdPerfil { get; set; }
        public string Perfil { get; set; }

        public virtual ICollection<Ofertas> Ofertas { get; set; }
    }
}
