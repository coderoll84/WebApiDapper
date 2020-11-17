using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ConocimientosPorOferta
    {
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public int IdConocimiento { get; set; }

        public virtual Conocimientos IdConocimientoNavigation { get; set; }
        public virtual Ofertas IdOfertaNavigation { get; set; }
    }
}
