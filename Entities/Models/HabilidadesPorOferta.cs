using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class HabilidadesPorOferta
    {
        public int Id { get; set; }
        public int? IdOferta { get; set; }
        public int? IdHabilidad { get; set; }

        public virtual Habilidades IdHabilidadNavigation { get; set; }
        public virtual Ofertas IdOfertaNavigation { get; set; }
    }
}
