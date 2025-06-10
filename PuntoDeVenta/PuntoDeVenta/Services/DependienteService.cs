using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    public class DependienteService : IDependienteService
    {
        private readonly DependienteContext _context;

        public DependienteService(DependienteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dependiente>> GetAll()
        {
            return await _context.Dependiente.ToListAsync();
        }

        public async Task<Dependiente> Add(Dependiente d)
        {
            await _context.Dependiente.AddAsync(d);
            await _context.SaveChangesAsync();
            return d;
        }
    }

    public interface IDependienteService
    {
        Task<IEnumerable<Dependiente>> GetAll();
        Task<Dependiente> Add(Dependiente d);
    }
}