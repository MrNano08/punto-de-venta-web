using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options) { }

        public DbSet<Inventario> Inventario { get; set; }
    }

    public class Inventario
    {
        [Key]
        [Column("idInventario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public int IdProducto { get; set; }
    }
}