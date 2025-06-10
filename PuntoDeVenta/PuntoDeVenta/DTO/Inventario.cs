using Newtonsoft.Json;
using System;

namespace PuntoDeVenta.DTO
{
    public class InventarioDTO
    {
        [JsonProperty("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("observacion")]
        public string Observacion { get; set; }

        [JsonProperty("idProducto")]
        [JsonIgnore]
        public int IdProducto { get; set; }
    }
}