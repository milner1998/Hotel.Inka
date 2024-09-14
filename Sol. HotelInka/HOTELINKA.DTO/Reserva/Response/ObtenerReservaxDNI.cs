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
    public class ObtenerReservaxDNI
    {

    [SwaggerSchema("identificador reserva")]
    [JsonPropertyName("idReserva")]
    public int IdReserva { get; set; }

    [SwaggerSchema("Identificador del Huesped")]
    [JsonPropertyName("idHuesped")]
    public int IdHuesped { get; set; }

    [SwaggerSchema("Fecha de ingreso")]
    [JsonPropertyName("fechInggreso")]
    public DateTime FechaIngreso { get; set; }

    [SwaggerSchema("Fecha de Salida")]
    [JsonPropertyName("fechSalida")]
    public DateTime FechaSalida { get; set; }

    [SwaggerSchema("Tipo de Habitacion")]
    [JsonPropertyName("tipoHabitacion")]
    public string TipoHabiracion { get; set; }

    [SwaggerSchema("Descripcion de la habitacion")]
    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

    [SwaggerSchema("Capacidad de la habitacion")]
    [JsonPropertyName("capHabitacion")]
    public int Capacidad { get; set; }

    [SwaggerSchema("Estado de la habitacion")]
    [JsonPropertyName("estado")]
    public string EstadoHabitacion { get; set; }
    }
}
