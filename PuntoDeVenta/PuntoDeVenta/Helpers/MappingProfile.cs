// Helpers/MappingProfile.cs
using AutoMapper;
using PuntoDeVenta.Data;
using PuntoDeVenta.DTO;

namespace PuntoDeVenta.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dependiente, DependienteDTO>().ReverseMap();
            CreateMap<Factura, FacturaDTO>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaDTO>().ReverseMap();
            CreateMap<Inventario, InventarioDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<DetallePedido, DetallePedidoDTO>().ReverseMap();
            CreateMap<Oferta, OfertaDTO>().ReverseMap();
        }
    }
}
