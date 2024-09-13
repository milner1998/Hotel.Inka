using HOTELINKA.DOMAIN.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Interface
{
    public interface IReservaRepository 
    {
        Task<int?> GetLastCodigoReservaAsync();

        Task<List<CatalogoHabitaciones>> GetCatalogoHabitaciones();

        Task<Reserva> AddReservaAsync(Reserva reserva);

        Task<Reserva> GetClienteByDNI(string dni);

        Task<OrdenDeHospedaje> AddOrdenHospedajeAsync(OrdenDeHospedaje ordenDeHospedaje);

        /*Task<Reserva> GetReservaXDNI(string dni);*/
    }
}
