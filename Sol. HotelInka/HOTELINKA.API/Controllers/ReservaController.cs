using HOTELINKA.APPLICATION;
using HOTELINKA.DTO.Reserva.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HOTELINKA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly IRservaService _reservaService;

        public ReservaController(
            IRservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [SwaggerOperation(
        Summary = "Servicio que agrega una reserva nueva",
        OperationId = "AddReservaAsync")]
        [SwaggerResponse(200, "Reserva agregado correctamente")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpPost("addReservaAsync")]
        public async Task<IActionResult> AddReservaAsync([FromBody] RegistrarReservaRequest request)
        {
            return Ok(await _reservaService.AddReservaAsync(request));
        }

        [SwaggerOperation(
       Summary = "Servicio que obtiene todas las habitaciones disponibles",
       OperationId = "ObtenerCalogoHabitacionesAsync")]
        [SwaggerResponse(200, "Catalogo Disponibles")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("obtenerCalogoHabitacionesAsync")]
        public async Task<IActionResult> ObtenerCalogoHabitacionesAsync()
        {
            return Ok(await _reservaService.ObtenerCalogoHabitacionesAsync());
        }

        [SwaggerOperation(
        Summary = "Servicio que obtiene el DNI del cliente",
        OperationId = "ObtenerClienteXDNIAsync")]
        [SwaggerResponse(200, "Servicio que Obtiene la informacion del cliente por DNI")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("obtenerClienteXDNIAsync")]
        public async Task<IActionResult> ObtenerClienteXDNIAsync([FromQuery] string dni)
        {
            return Ok(await _reservaService.ObtenerClienteXDNIAsync(dni));
        }
        
        [SwaggerOperation(
        Summary = "Obtener Reserva del cliente por medio de su DNI",
        OperationId = " ObtenerReservaDNIAsync")]
        [SwaggerResponse(200, "Servicio que Obtiene la informacion del cliente por DNI")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("ObtenerReservaDNIAsync")]
        public async Task<IActionResult> ObtenerReservaDNIAsync([FromQuery] int idhueped)
        {
            return Ok(await _reservaService.ObtenerReservaDNIAsync(idhueped));
        }

        [SwaggerOperation(
        Summary = "Servicio que agrega una Orden de Hospedaje",
        OperationId = "AddOrdenHospedajeAsync")]
        [SwaggerResponse(200, "Orden de Hospedaje")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpPost("AddOrdenHospejaeAsync")]
        public async Task<IActionResult> AddOrdenHospedajeAsync([FromBody] RegistrarOrdenHospedaje request)
        {
            return Ok(await _reservaService.AddOrdenHospedajeAsync(request));
        }

        [SwaggerOperation(
        Summary = "Servicio que obtiene los detalles de la orden de hospedaje",
        OperationId = "ObtenerOrdenHospedajeAsync")]
        [SwaggerResponse(200, "Servicio que Obtiene la orden de hospedaje por medio del DNI")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("ObtenerOrdenHospedajeAsync")]
        public async Task<IActionResult> ObtenerOrdenHospedajeAsync([FromQuery] string DNI)
        {
            return Ok(await _reservaService.ObtenerOrdenHospedajeAsync(DNI));
        }

        [SwaggerOperation(
        Summary = "Servicio que obtiene el catalogo de servicios por tipo de servicio",
        OperationId = "ObtenerCatalogoXTipoAsync")]
        [SwaggerResponse(200, "Servicio que Obtiene el catalogo de servicios por tipo")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("ObtenerCatalogoXTipoAsync")]
        public async Task<IActionResult> ObtenerCatalogoXTipoAsync([FromQuery] int a)
        {
            return Ok(await _reservaService.ObtenerCatalogoXTipoAsync(a));
        }

        [SwaggerOperation(
        Summary = "Obtener Tipos de Servicios",
        OperationId = " ObtenerTipoServicioAsync")]
        [SwaggerResponse(200, "Servicio que Obtiene la informacion del cliente por DNI")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("ObtenerTipoServicioAsync")]
        public async Task<IActionResult> ObtenerTipoServicioAsync([FromQuery] int id)
        {
            return Ok(await _reservaService.ObtenerTipoServicioAsync(id));
        }
        /*[SwaggerOperation(
        Summary = "Servicio que obtiene las reservas del cliente",
        OperationId = "ObtenerReservaxDNI")]
        [SwaggerResponse(200, "Servicio que Obtiene la informacion del cliente por DNI")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("ObtenerReservarxDNIAsync")]
        public async Task<IActionResult> ObtenerReservarxDNIAsync(string dni)
        {
            return Ok(await _reservaService.ObtenerReservarxDNIAsync(dni));
        }*/
    }
}
