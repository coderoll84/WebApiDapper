using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TiposConocimiento
    {
        public TiposConocimiento()
        {
            Conocimientos = new HashSet<Conocimientos>();
        }

        public int IdTipoConocimiento { get; set; }
        public string TipoConocimiento { get; set; }

        public virtual ICollection<Conocimientos> Conocimientos { get; set; }
    }
}
