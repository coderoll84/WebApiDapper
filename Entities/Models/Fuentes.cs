using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Fuentes
    {
        public Fuentes()
        {
            Ofertas = new HashSet<Ofertas>();
        }

        public int IdFuente { get; set; }
        public string Fuente { get; set; }

        public virtual ICollection<Ofertas> Ofertas { get; set; }
    }
}
