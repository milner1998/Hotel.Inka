using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Response
{
    public class ObtenerCalogoHabitacionesDTO
    {
        [SwaggerSchema("Identificador de la habitacion")]
        [JsonPropertyName("idHabitacion")]
        public int id_Habitacion { get; set; }

        [SwaggerSchema("Numero de Habitaciones")]
        [JsonPropertyName("numHabitacion")]
        public string num_Habitacion { get; set; }

        [SwaggerSchema("Tipo de Habitacion")]
        [JsonPropertyName("tipoHabitacion")]
        public string Tipo_Habitacion { get; set; }

        [SwaggerSchema("Capacidad")]
        [JsonPropertyName("capacidad")]
        public int Capacidad { get; set; }

        [SwaggerSchema("Precio por noche")]
        [JsonPropertyName("precioxNoche")]
        public decimal PRECIOXNOCHE { get; set; }

        [SwaggerSchema("Descripcion de la habitacion")]
        [JsonPropertyName("descripcionHabitacion")]
        public string DESCRIPCION_HABITACION { get; set; }

        [SwaggerSchema("Estado de la Habitacion")]
        [JsonPropertyName("estadoHabitacion")]
        public string ESTADO_HABITACION { get; set; }
    }
}
