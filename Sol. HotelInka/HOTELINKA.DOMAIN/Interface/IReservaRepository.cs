using HOTELINKA.DOMAIN.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Interface
{
    public interface IReservaRepository
    {
        Task<int?> GetLastCodigoReservaAsync();

        Task<List<CatalogoHabitaciones>> GetAllCatalogoHabitaciones();

        Task<Reserva> AddReservaAsync(Reserva reserva);
    }
}
