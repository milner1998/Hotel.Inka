using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Response
{
    public class ObtenerReservaDTO
    {
        [SwaggerSchema("Numero de la habitacion")]
        [JsonPropertyName("nroHabitacion")]
        public string TipoHabitacion { get; set; }

        [SwaggerSchema("Descripcion de la habitacion")]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [SwaggerSchema("Capacidad de la habitacion")]
        [JsonPropertyName("capHabitacion")]
        public int Capacidad { get; set; }

    }
}
