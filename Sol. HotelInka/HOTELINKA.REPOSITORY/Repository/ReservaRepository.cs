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

        public async Task<Huesped> GetClienteByDNI(string dni)
        {
            return await All<Huesped>().AsNoTracking()
                .Where(huesped => huesped.DNI_CLIENTE == dni).FirstOrDefaultAsync();
                
        }
        public async Task<List<Reserva>> GetReservasxCliente(int idhuesped)
        {
            return await All<Reserva>()
            .Where(r => r.ID_HUESPED == idhuesped && r.ESTADO_RESERVA == "PAGADO").ToListAsync(); ;
        }


        public async Task<List<CatalogoHabitaciones>> GetCatalogoHabitaciones()
        {
            return await All<CatalogoHabitaciones>()
            .Where(CatalogoHabitaciones => CatalogoHabitaciones.ESTADO_HABITACION == "Disponible").ToListAsync();;
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

        /*public async Task<Reserva> GetReservaXDNI(string dni)
        {
            return await All<Reserva>().AsNoTracking()
                .Where(reserva => reserva.DNI_CLIENTE == dni).FirstOrDefaultAsync();
        }*/

    }
}
