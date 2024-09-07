using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.REPOSITORY.Context;
using System.Threading.Tasks;

namespace HOTELINKA.REPOSITORY.Repository
{
    public class ReservaRepository : BaseRepository, IReservaRepository
    {
        private HotelInkaContext _context;
        public ReservaRepository(HotelInkaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Reserva> AddReservaAsync(Reserva reserva)
        {
            await InsertAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

    }
}
