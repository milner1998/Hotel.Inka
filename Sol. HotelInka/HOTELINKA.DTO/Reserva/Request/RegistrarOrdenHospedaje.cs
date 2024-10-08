using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Request
{
    public class RegistrarOrdenHospedaje
    {
        [JsonPropertyName("idOrdenHospedaje")]
        [SwaggerSchema("idorden")]
        public string IdOrdenHodepaje { get; set; }

        [JsonPropertyName("idReserva")]
        [SwaggerSchema("idreserva")]
        public int IdReserva{ get; set; }

        [JsonPropertyName("idHuesped")]
        [SwaggerSchema("idhuesped")]
        public int IdHuesped { get; set; }

        [JsonPropertyName("idHabitacion")]
        [SwaggerSchema("idHabtiacion")]
        public int IdHabitacion { get; set; }

        [JsonPropertyName("fechaInicio")]
        [SwaggerSchema("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("fechaFin")]
        [SwaggerSchema("fechSalida.")]
        public DateTime FechaFin { get; set; }

        [JsonPropertyName("totalPago")]
        [SwaggerSchema("totalPago")]
        public decimal TotalPago { get; set; }

        [SwaggerSchema("EstadodelaOrdenHospedaje")]
        [JsonPropertyName("estadoOrden")]
        public string EstadoOrdenHospedaje { get; set; }
    }
}
