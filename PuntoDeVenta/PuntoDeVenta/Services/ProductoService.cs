using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ProductoContext _context;

        public ProductoService(ProductoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> Get(string[] ids)
        {
            var intIds = ids?.Select(id => int.TryParse(id, out var parsed) ? parsed : (int?)null)
                .Where(x => x != null)
                .Select(x => x.Value)
                .ToList();

            var query = _context.Producto.AsQueryable();
            if (intIds != null && intIds.Any())
                query = query.Where(x => intIds.Contains(x.Id));

            return await query.ToListAsync();
        }

        public async Task<Producto> Add(Producto p)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "INSERT INTO Producto (nombre, descripcion, tipo, precio, stock) VALUES ({0}, {1}, {2}, {3}, {4})",
                p.Nombre, p.Descripcion, p.Tipo, p.Precio, p.Stock
            );

            return p;
        }


        public async Task<Producto> Update(Producto p)
        {
            var existente = await _context.Producto.FindAsync(p.Id);
            if (existente == null) return null;

            existente.Nombre = p.Nombre;
            existente.Descripcion = p.Descripcion;
            existente.Tipo = p.Tipo;
            existente.Precio = p.Precio;
            existente.Stock = p.Stock;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> Delete(Producto p)
        {
            var existente = await _context.Producto.FindAsync(p.Id);
            if (existente == null) return false;

            _context.Producto.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public interface IProductoService
    {
        Task<IEnumerable<Producto>> Get(string[] ids);
        Task<Producto> Add(Producto p);
        Task<Producto> Update(Producto p);
        Task<bool> Delete(Producto p);
    }
}