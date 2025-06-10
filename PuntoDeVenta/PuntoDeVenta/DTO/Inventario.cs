using Newtonsoft.Json;
using System;

namespace PuntoDeVenta.DTO
{
    public class InventarioDTO
    {

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("observacion")]
        public string Observacion { get; set; }

        [JsonProperty("idProducto")]
        public int IdProducto { get; set; }
    }
}