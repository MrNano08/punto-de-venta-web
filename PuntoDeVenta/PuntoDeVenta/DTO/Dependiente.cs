using Newtonsoft.Json;

namespace PuntoDeVenta.DTO
{
    public class DependienteDTO
    {


        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellidos")]
        public string Apellidos { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("origen")]
        public string Origen { get; set; }
    }
}

