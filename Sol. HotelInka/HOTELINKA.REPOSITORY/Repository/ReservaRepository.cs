using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.REPOSITORY.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<int?> GetLastCodigoReservaAsync()
        {
            var ultimaReserva = await All<Reserva>()
                .OrderByDescending(r => r.ID).FirstOrDefaultAsync();

            return ultimaReserva?.ID;
        }


    }
}
