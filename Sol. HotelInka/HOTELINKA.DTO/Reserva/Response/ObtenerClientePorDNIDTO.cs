using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace HOTELINKA.DTO.Reserva.Response
{
    public class ObtenerClientePorDNIDTO
    {

    [SwaggerSchema("Dni del cliente")]
    [JsonPropertyName("DNI_CLIENTE")]
        public string dniCliente { get; set; }

    [SwaggerSchema("Nombre")]
    [JsonPropertyName("nomCliente")]
        public string NomCliente { get; set; }

    [SwaggerSchema("Apellido")]
    [JsonPropertyName("apeCliente")]
        public string ApeCliente { get; set; }

    [SwaggerSchema("Telefono")]
    [JsonPropertyName("telefonoCliente")]
        public string telefonoCliente { get; set; }

    [SwaggerSchema("Correo")]
    [JsonPropertyName("correoCliente")]

    public string correoCliente { get; set; }
    [SwaggerSchema("Numero de la habitacion")]
    [JsonPropertyName("tipoHabitacion")]
        public string TipoHabitacion { get; set; }

    [SwaggerSchema("Descripcion de la habitacion")]
    [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

    [SwaggerSchema("Capacidad de la habitacion")]
    [JsonPropertyName("capHabitacion")]
        public int Capacidad { get; set; }
    }
}
