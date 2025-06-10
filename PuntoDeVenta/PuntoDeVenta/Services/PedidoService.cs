using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoContext _context;

        public PedidoService(PedidoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _context.Pedido.ToListAsync();
        }

        public async Task<Pedido> AddPedido(Pedido pedido, List<DetallePedido> detalles)
        {
            await _context.Pedido.AddAsync(pedido);
            await _context.SaveChangesAsync();

            foreach (var d in detalles)
            {
                d.IdPedido = pedido.Id;
                await _context.DetallePedidos.AddAsync(d);
            }

            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<IEnumerable<DetallePedido>> GetDetalles(int pedidoId)
        {
            return await _context.DetallePedidos.Where(d => d.IdPedido == pedidoId).ToListAsync();
        }
    }

    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> AddPedido(Pedido pedido, List<DetallePedido> detalles);
        Task<IEnumerable<DetallePedido>> GetDetalles(int pedidoId);
    }
}