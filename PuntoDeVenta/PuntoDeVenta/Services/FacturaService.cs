using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly FacturaContext _context;

        public FacturaService(FacturaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAll()
        {
            return await _context.Factura.ToListAsync();
        }

        public async Task<Factura> AddFactura(Factura factura, List<DetalleFactura> detalles)
        {
            await _context.Factura.AddAsync(factura);
            await _context.SaveChangesAsync();

            foreach (var d in detalles)
            {
                d.IdFactura = factura.Id;
                await _context.DetalleFactura.AddAsync(d);
            }

            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task<IEnumerable<DetalleFactura>> GetDetalles(int facturaId)
        {
            return await _context.DetalleFactura.Where(d => d.IdFactura == facturaId).ToListAsync();
        }
    }

    public interface IFacturaService
    {
        Task<IEnumerable<Factura>> GetAll();
        Task<Factura> AddFactura(Factura factura, List<DetalleFactura> detalles);
        Task<IEnumerable<DetalleFactura>> GetDetalles(int facturaId);
    }
}