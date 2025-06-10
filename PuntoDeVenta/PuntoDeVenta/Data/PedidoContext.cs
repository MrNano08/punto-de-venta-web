using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options)
            : base(options) { }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
    }

    public class Pedido
    {
        [Key]
        [Column("idPedido")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public int IdProveedor { get; set; }
    }

    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
    }
}
