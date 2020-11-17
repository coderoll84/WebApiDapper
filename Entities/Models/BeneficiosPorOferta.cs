using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class BeneficiosPorOferta
    {
        public int Id { get; set; }
        public int? IdOferta { get; set; }
        public int? IdBeneficio { get; set; }

        public virtual Beneficios IdBeneficioNavigation { get; set; }
        public virtual Ofertas IdOfertaNavigation { get; set; }
    }
}
