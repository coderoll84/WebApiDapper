using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Requisitos
    {
        public Requisitos()
        {
            RequisitosPorOferta = new HashSet<RequisitosPorOferta>();
        }

        public int IdRequisito { get; set; }
        public string Requisito { get; set; }

        public virtual ICollection<RequisitosPorOferta> RequisitosPorOferta { get; set; }
    }
}
