using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly InventarioContext _context;

        public InventarioService(InventarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventario>> GetAll()
        {
            return await _context.Inventario.ToListAsync();
        }

        public async Task<Inventario> Add(Inventario inv)
        {
            await _context.Inventario.AddAsync(inv);
            await _context.SaveChangesAsync();
            return inv;
        }
    }

    public interface IInventarioService
    {
        Task<IEnumerable<Inventario>> GetAll();
        Task<Inventario> Add(Inventario inv);
    }
}
