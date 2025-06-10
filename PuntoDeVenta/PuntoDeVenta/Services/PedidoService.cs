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
            await _context.SaveChangesAsync(); // aquí EF usa OUTPUT, pero si no hay trigger en Pedido, no hay problema

            foreach (var d in detalles)
            {
                d.idPedido = pedido.Id;

                await _context.Database.ExecuteSqlRawAsync(@"
            INSERT INTO DetallePedido (idPedido, idProducto, cantidad)
            VALUES ({0}, {1}, {2})",
                    d.idPedido, d.idProducto, d.cantidad);
            }

            return pedido;
        }


        public async Task<IEnumerable<DetallePedido>> GetDetalles(int pedidoId)
        {
            return await _context.DetallePedido.Where(d => d.idPedido == pedidoId).ToListAsync();
        }
    }

    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> AddPedido(Pedido pedido, List<DetallePedido> detalles);
        Task<IEnumerable<DetallePedido>> GetDetalles(int pedidoId);
    }
}