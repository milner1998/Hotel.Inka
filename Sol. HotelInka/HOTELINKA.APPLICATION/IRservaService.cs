using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;
using HOTELINKA.DTO.Reserva.Response;

namespace HOTELINKA.APPLICATION
{
    public interface IRservaService
    {
        Task<ResponseDTO> AddReservaAsync(RegistrarReservaRequest request);
        Task<List<ObtenerCalogoHabitacionesDTO>> ObtenerCalogoHabitacionesAsync();
        Task<ObtenerClientePorDNIDTO> ObtenerClienteXDNIAsync(string dni);

        Task<List<ObtenerReservaxDNI>> ObtenerReservaDNIAsync(int idhuesped);

        Task<ResponseDTO> AddOrdenHospedajeAsync(RegistrarOrdenHospedaje request);

        Task<ObtenerOrdenHospedajeXDNI> ObtenerOrdenHospedajeAsync (string DNI);

        Task<List<ObtenerCatalogoXTipoDTO>> ObtenerCatalogoXTipoAsync(int a);

        Task<ObtenerTiposServiciosDTO> ObtenerTipoServicioAsync(int id);

        /*Task<ObtenerReservaDTO> ObtenerReservarxDNIAsync(string dni);*/
    }
}
