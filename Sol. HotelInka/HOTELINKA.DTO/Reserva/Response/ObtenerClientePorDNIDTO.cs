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

    }
}
