using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data
{
    public class OfertaContext : DbContext
    {
        public OfertaContext(DbContextOptions<OfertaContext> options)
            : base(options) { }

        public DbSet<Oferta> Oferta { get; set; }
    }

    public class Oferta
    {
        [Key]
        [Column("idOferta")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TipoOferta { get; set; }
        public string Descripcion { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
