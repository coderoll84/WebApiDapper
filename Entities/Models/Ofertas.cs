using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Ofertas
    {
        public Ofertas()
        {
            BeneficiosPorOferta = new HashSet<BeneficiosPorOferta>();
            ConocimientosPorOferta = new HashSet<ConocimientosPorOferta>();
            HabilidadesPorOferta = new HashSet<HabilidadesPorOferta>();
            RequisitosPorOferta = new HashSet<RequisitosPorOferta>();
        }

        public int IdOferta { get; set; }
        public int IdFuente { get; set; }
        public int IdPerfil { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
        public int? IdMunicipio { get; set; }
        public decimal? SalarioMin { get; set; }
        public decimal? SalarioMax { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual Fuentes IdFuenteNavigation { get; set; }
        public virtual Perfiles IdPerfilNavigation { get; set; }
        public virtual ICollection<BeneficiosPorOferta> BeneficiosPorOferta { get; set; }
        public virtual ICollection<ConocimientosPorOferta> ConocimientosPorOferta { get; set; }
        public virtual ICollection<HabilidadesPorOferta> HabilidadesPorOferta { get; set; }
        public virtual ICollection<RequisitosPorOferta> RequisitosPorOferta { get; set; }
    }
}
