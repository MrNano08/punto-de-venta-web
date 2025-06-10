using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly OfertaContext _context;

        public OfertaService(OfertaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Oferta>> GetAll()
        {
            return await _context.Oferta.ToListAsync();
        }

        public async Task<Oferta> Add(Oferta o)
        {
            await _context.Oferta.AddAsync(o);
            await _context.SaveChangesAsync();
            return o;
        }
    }

    public interface IOfertaService
    {
        Task<IEnumerable<Oferta>> GetAll();
        Task<Oferta> Add(Oferta o);
    }
}