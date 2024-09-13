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
        [SwaggerSchema("Documento de identidad del cliente")]
        public int IdOrdenHodepaje { get; set; }

        [JsonPropertyName("codOrdenHospedaje")]
        [SwaggerSchema("Documento de identidad del cliente")]
        public string codOrdenHospedaje { get; set; }

        [JsonPropertyName("idReserva")]
        [SwaggerSchema("Nombre del cliente.")]
        public int IdReserva{ get; set; }

        [JsonPropertyName("idHuesped")]
        [SwaggerSchema("Apellido del cliente.")]
        public int IdHuesped { get; set; }

        [JsonPropertyName("idHabitacion")]
        [SwaggerSchema("Correo Electronico del cliente.")]
        public int IdHabitacion { get; set; }

        [JsonPropertyName("fechaInicio")]
        [SwaggerSchema("Telefono del cliente.")]
        public DateTime FechaInicio { get; set; }

        [JsonPropertyName("fechaFin")]
        [SwaggerSchema("Fecha ingreso de la reserva.")]
        public DateTime FechaFin { get; set; }

        [JsonPropertyName("totalPago")]
        [SwaggerSchema("Fecha salida de la reserva.")]
        public decimal TotalPago { get; set; }

        [SwaggerSchema("EstadodelaOrdenHospedaje")]
        [JsonPropertyName("estadoHabitacion")]
        public string EstadoOrdenHospedaje { get; set; }
    }
}
