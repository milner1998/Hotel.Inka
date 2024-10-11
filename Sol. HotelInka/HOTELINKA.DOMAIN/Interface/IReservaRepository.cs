using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Interface
{
    public interface IReservaRepository 
    {
        Task<string?> GetLastCodigoReservaAsync();

        Task<List<CatalogoHabitaciones>> GetCatalogoHabitaciones();

        Task<Reserva> AddReservaAsync(Reserva reserva);

        Task<t04_huesped> GetClienteByDNI(string dni);

        Task<List<Reserva>> GetReservasxCliente(int idhuesped);

        Task<t01_orden_de_hospedaje> AddOrdenHospedajeAsync(t01_orden_de_hospedaje ordenDeHospedaje);

        Task<ConsultaHuespedDetalle> GetOrdenDeHospedajeXDNI (string DNI);

        Task<List<ConsultarCatalogoXTipo>> GetObtenerCatalogoXTipo(int a);

        Task<t07_tipo_servicio> GetTipoServicio(int id);

        /*Task<Reserva> GetReservaXDNI(string dni);*/
    }
}
