using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Data
{
    public class DependienteContext : DbContext
    {
        public DependienteContext(DbContextOptions<DependienteContext> options)
            : base(options) { }

        public DbSet<Dependiente> Dependiente { get; set; }
    }

    public class Dependiente
    {
        [Key]
        [Column("idDependiente")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Origen { get; set; }
    }
}
