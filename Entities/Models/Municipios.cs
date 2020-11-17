using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Municipios
    {
        public Guid Id { get; set; }
        public Guid IdEstado { get; set; }
        public string Municipio { get; set; }
    }
}
