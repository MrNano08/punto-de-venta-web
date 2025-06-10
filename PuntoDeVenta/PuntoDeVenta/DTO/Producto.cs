using Newtonsoft.Json;

namespace PuntoDeVenta.DTO
{
    public class ProductoDTO
    {
        [JsonProperty("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; } // Unidad o Lote

        [JsonProperty("precio")]
        public decimal Precio { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }
    }
}
