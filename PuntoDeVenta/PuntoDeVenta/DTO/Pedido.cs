using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PuntoDeVenta.DTO
{
    public class PedidoDTO
    {
        [JsonProperty("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("fechaPedido")]
        public DateTime FechaPedido { get; set; }

        [JsonProperty("idProveedor")]
        public int IdProveedor { get; set; }

        [JsonProperty("detalles")]
        public List<DetallePedidoDTO> Detalles { get; set; }
    }

    public class DetallePedidoDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idPedido")]
        public int IdPedido { get; set; }

        [JsonProperty("idProducto")]
        public int IdProducto { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
    }
}