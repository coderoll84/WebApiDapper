using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Beneficios
    {
        public Beneficios()
        {
            BeneficiosPorOferta = new HashSet<BeneficiosPorOferta>();
        }

        public int IdBeneficio { get; set; }
        public string Beneficio { get; set; }

        public virtual ICollection<BeneficiosPorOferta> BeneficiosPorOferta { get; set; }
    }
}
