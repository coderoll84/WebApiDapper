using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Habilidades
    {
        public Habilidades()
        {
            HabilidadesPorOferta = new HashSet<HabilidadesPorOferta>();
        }

        public int IdHabilidad { get; set; }
        public string Habilidad { get; set; }

        public virtual ICollection<HabilidadesPorOferta> HabilidadesPorOferta { get; set; }
    }
}
