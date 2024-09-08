using HOTELINKA.APPLICATION;
using HOTELINKA.DTO.Reserva.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HOTELINKA.API.Controllers
{
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

    }
}
