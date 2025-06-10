using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PuntoDeVenta.DTO
{
    public class FacturaDTO
    {
        [JsonProperty("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("idDependiente")]
        public int IdDependiente { get; set; }

        [JsonProperty("detalles")]
        public List<DetalleFacturaDTO> Detalles { get; set; }
    }

    public class DetalleFacturaDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idFactura")]
        public int IdFactura { get; set; }

        [JsonProperty("idProducto")]
        public int IdProducto { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty("precioUnitario")]
        public decimal PrecioUnitario { get; set; }
    }
}
