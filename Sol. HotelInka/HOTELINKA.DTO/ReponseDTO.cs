using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace HOTELINKA.DTO
{
    public class ResponseDTO<T> : ResponseDTO
    {
        [SwaggerSchema("Lista de objetos obtenidos del servicio.")]
        public List<T> Values { get; set; }

        [SwaggerSchema("Objeto obtenido del servicio.")]
        public T Value { get; set; }

        [SwaggerSchema("Cantidad de datos obtenidos de una lista.")]
        public int Count => Values?.Count ?? 0;

        [SwaggerSchema("Lista de errores.")]
        public List<string> Errors { get; set; }

        public Exception Exception { get; set; }

        public static ResponseDTO<T> List(List<T> values) => new ResponseDTO<T> { Success = true, Values = values };

        public static ResponseDTO<T> Single(T value) => new ResponseDTO<T> { Success = true, Value = value };

        public static ResponseDTO<T> Ok(string msg = null) => new ResponseDTO<T> { Success = true, Message = msg };

        public static ResponseDTO<T> BadRequest(string msg) => new ResponseDTO<T> { Success = false, Message = msg };

        public static ResponseDTO<T> BadRequest(Exception ex) => new ResponseDTO<T> { Success = false, Exception = ex };

        public static ResponseDTO<T> Error(List<string> errors) => new ResponseDTO<T> { Errors = errors };

        public ResponseDTO()
        {

        }

        public ResponseDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResponseDTO(string message)
        {
            Message = message;
        }

        public ResponseDTO(bool success)
        {
            Success = success;
        }
    }
    public class ResponseDTO
    {
        [SwaggerSchema("Identificador de la entidad")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [SwaggerSchema("Identificador del usuario")]
        [JsonPropertyName("idUsuario")]
        public Guid IdUsuario { get; set; }

        [SwaggerSchema("Flag que indica que la transacción es correcta.")]
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [SwaggerSchema("Código de error que identifica si es una advertencia o un error")]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [SwaggerSchema("Título de mensaje de error o validación de la transacción")]
        [JsonPropertyName("titleMessage")]
        public string TitleMessage { get; set; }

        [SwaggerSchema("Mensaje de error o validación de la transacción")]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [SwaggerSchema("Valor del objeto")]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [SwaggerSchema("Valor de la moneda cambiada")]
        [JsonPropertyName("currencyValue")]
        public decimal CurrencyValue { get; set; }

        public ResponseDTO()
        {

        }

        public ResponseDTO(string message)
        {
            Message = message;
        }

        public ResponseDTO(bool success)
        {
            Success = success;
        }
        public ResponseDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}

