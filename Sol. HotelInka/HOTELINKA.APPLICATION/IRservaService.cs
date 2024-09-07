using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;

namespace HOTELINKA.APPLICATION
{
    public interface IRservaService
    {
        Task<ResponseDTO> AddReservaAsync(RegistrarReservaRequest request);
    }
}
