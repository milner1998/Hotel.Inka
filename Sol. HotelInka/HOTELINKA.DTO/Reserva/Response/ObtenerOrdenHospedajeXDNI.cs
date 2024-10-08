using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Response
{
    public class ObtenerOrdenHospedajeXDNI
    {
        [SwaggerSchema("Nombre")]
        [JsonPropertyName("idOrdenHospedaje")]
        public string NombreHuesped { get; set; }

        [SwaggerSchema("Apellido")]
        [JsonPropertyName("dniCliente")]
        public string ApellidoHuesped { get; set; }

        [SwaggerSchema("Nro orden de hospedaje")]
        [JsonPropertyName("NroOrden")]
        public string NroOrdenHospedaje { get; set; }

        [SwaggerSchema("Fecha de ingreso")]
        [JsonPropertyName("FechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [SwaggerSchema("Fecha de saida")]
        [JsonPropertyName("fechaSalida")]
        public DateTime FechaSalida { get; set; }

        [SwaggerSchema("Nro de habitacion")]
        [JsonPropertyName("nroHabitacion")]
        public int NumeroHabitacion { get; set; }

        [SwaggerSchema("Tipo de habitacion")]
        [JsonPropertyName("tipoHabitacion")]
        public string TipoHabitacion { get; set; }
    }
}
