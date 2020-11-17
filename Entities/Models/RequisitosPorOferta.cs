using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RequisitosPorOferta
    {
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public int IdRequisito { get; set; }

        public virtual Ofertas IdOfertaNavigation { get; set; }
        public virtual Requisitos IdRequisitoNavigation { get; set; }
    }
}
