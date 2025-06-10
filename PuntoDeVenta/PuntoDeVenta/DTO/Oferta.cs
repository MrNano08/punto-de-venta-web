using Newtonsoft.Json;
using System;

namespace PuntoDeVenta.DTO
{
    public class OfertaDTO
    {
        [JsonProperty("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("tipoOferta")]
        public string TipoOferta { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("idProducto")]
        public int IdProducto { get; set; }

        [JsonProperty("fechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonProperty("fechaFin")]
        public DateTime FechaFin { get; set; }
    }
}