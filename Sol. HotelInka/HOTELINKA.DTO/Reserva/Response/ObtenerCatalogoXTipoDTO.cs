using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Response
{
    public class ObtenerCatalogoXTipoDTO
    {
        [SwaggerSchema("id del servicio")]
        [JsonPropertyName("idServicio")]
        public string idServicio { get; set; }

        [SwaggerSchema("Nombre del servicio")]
        [JsonPropertyName("nombreServicio")]
        public string nombreServicio { get; set; }

        [SwaggerSchema("Descripcion del servicio")]
        [JsonPropertyName("descripcionServicio")]
        public string descripcionServicio { get; set; }

        [SwaggerSchema("Precio del servicio")]
        [JsonPropertyName("precioServicio")]
        public decimal precioServcio { get; set; }
    }
}
