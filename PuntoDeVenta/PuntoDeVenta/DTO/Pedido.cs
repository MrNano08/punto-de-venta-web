using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.DTO
{
    public class PedidoDTO
    {
        [JsonProperty("id")]
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

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
        public int Id { get; set; }

        [JsonProperty("idPedido")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdPedido { get; set; }

        [JsonProperty("idProducto")]
        public int IdProducto { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }
    }
}