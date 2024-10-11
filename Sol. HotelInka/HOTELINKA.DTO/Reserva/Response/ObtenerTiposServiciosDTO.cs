using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Response
{
    public class ObtenerTiposServiciosDTO
    {

    [SwaggerSchema("Identificador del Tipo de servicio")]
    [JsonPropertyName("idTipoServicio")]
    public int idTipoServicio { get; set; }


    [SwaggerSchema("Nombre del servicio")]
    [JsonPropertyName("tipoServicio")]
    public string TIPO { get; set; }
    }
}
