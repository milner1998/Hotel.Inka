using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.REPOSITORY.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Reserva> GetClienteByDNI(string dni)
        {
            return await All<Reserva>().AsNoTracking()
                .Where(reserva => reserva.DNI_CLIENTE == dni).FirstOrDefaultAsync();
        }


        public async Task<List<CatalogoHabitaciones>> GetAllCatalogoHabitaciones()
        {
            return await All<CatalogoHabitaciones>()
            .ToListAsync();
        }

        public async Task<int?> GetLastCodigoReservaAsync()
        {
            var ultimaReserva = await All<Reserva>()
                .OrderByDescending(r => r.ID_RESERVA).FirstOrDefaultAsync();

            return ultimaReserva?.ID_RESERVA;
        }

        public async Task<OrdenDeHospedaje> AddOrdenHospedajeAsync(OrdenDeHospedaje ordenDeHospedaje)
        {
            await InsertAsync(ordenDeHospedaje);
            await _context.SaveChangesAsync();
            return ordenDeHospedaje;
        }

    }
}
