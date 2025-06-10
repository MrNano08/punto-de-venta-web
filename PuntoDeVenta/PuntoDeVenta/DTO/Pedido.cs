using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.DTO
{
    public class PedidoDTO
    {

        [JsonProperty("fechaPedido")]
        public DateTime FechaPedido { get; set; }

        [JsonProperty("idProveedor")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdProveedor { get; set; }

        [JsonProperty("detalles")]
        public List<DetallePedidoDTO> Detalles { get; set; }
    }

    public class DetallePedidoDTO
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("idPedido")]
        public int? IdPedido { get; set; }

        [JsonProperty("idProducto")]
        public int? IdProducto { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
    }
}