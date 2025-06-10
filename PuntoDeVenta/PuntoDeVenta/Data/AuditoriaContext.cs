using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta.Data
{
    public class AuditoriaContext : DbContext
    {
        public AuditoriaContext(DbContextOptions<AuditoriaContext> options) : base(options) { }

        public DbSet<Auditoria> Auditoria { get; set; }
    }

    public class Auditoria
    {
        [Key]
        [Column("idAuditoria")]
        public int Id { get; set; }

        public string Tabla { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Usuario { get; set; } // opcional
        public string Detalles { get; set; }
    }
}
