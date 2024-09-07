using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace HOTELINKA.DTO.Reserva.Request
{
    public class RegistrarReservaRequest
    {
        [JsonPropertyName("dniCliente")]
        [SwaggerSchema("Documento de identidad del cliente")]
        public string DniCliente { get; set; }

        [JsonPropertyName("nombreCliente")]
        [SwaggerSchema("Nombre del cliente.")]
        public string NombreCliente { get; set; }

        [JsonPropertyName("apellidoCliente")]
        [SwaggerSchema("Apellido del cliente.")]
        public string ApellidoCliente { get; set; }

        [JsonPropertyName("correoElectronico")]
        [SwaggerSchema("Correo Electronico del cliente.")]
        public string CorreoElectronico { get; set; }

        [JsonPropertyName("telefonoCliente")]
        [SwaggerSchema("Telefono del cliente.")]
        public string TelefonoCliente { get; set; }

        [JsonPropertyName("fechaIngreso")]
        [SwaggerSchema("Fecha ingreso de la reserva.")]
        public DateTime FechaIngreso { get; set; }

        [JsonPropertyName("fechaSalida")]
        [SwaggerSchema("Fecha salida de la reserva.")]
        public DateTime FechaSalida { get; set; }
    }
}
