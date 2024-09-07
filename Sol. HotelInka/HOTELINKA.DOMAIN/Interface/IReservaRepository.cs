using HOTELINKA.DOMAIN.Domain;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Interface
{
    public interface IReservaRepository
    {
        Task<int?> GetLastCodigoReservaAsync();

        Task<Reserva> AddReservaAsync(Reserva reserva);
    }
}
