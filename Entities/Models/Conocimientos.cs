using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Conocimientos
    {
        public Conocimientos()
        {
            ConocimientosPorOferta = new HashSet<ConocimientosPorOferta>();
        }

        public int IdConocimiento { get; set; }
        public string Conocimiento { get; set; }
        public int IdTipoConocimiento { get; set; }

        public virtual TiposConocimiento IdTipoConocimientoNavigation { get; set; }
        public virtual ICollection<ConocimientosPorOferta> ConocimientosPorOferta { get; set; }
    }
}
