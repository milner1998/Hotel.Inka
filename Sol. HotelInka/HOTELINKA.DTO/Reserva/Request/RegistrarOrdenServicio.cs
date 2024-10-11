using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOTELINKA.DTO.Reserva.Request
{
    public class RegistrarOrdenServicio
    {
                
        [SwaggerSchema("Identificador de la orden de Servicio")]
        [JsonPropertyName("idOrdenServicio")]
        public int Id_Orden_Servicio { get; set; }
                
        [SwaggerSchema("Identificador de la Orden de Hospedjar")]
        [JsonPropertyName("idOrdenHospedaje")]
       
        public string id_Orden_Hospedaje { get; set; }

        [SwaggerSchema("Identificador del Servicio")]
        [JsonPropertyName("idServicio")]
        public string id_Servicio { get; set; }

        [SwaggerSchema("Fecha de Solicitud")]
        [JsonPropertyName("fechaSolicitud")] 
        public DateTime fecchaSoliciutd { get; set; }

        [SwaggerSchema("Estado")]
        [JsonPropertyName("estado")]
        public string estado { get; set; }
    }   
}
