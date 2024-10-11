using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.DOMAIN.VO;
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

        public async Task<t04_huesped> GetClienteByDNI(string dni)
        {
            return await All<t04_huesped>().AsNoTracking()
                .Where(huesped => huesped.DNI_HUESPED == dni).FirstOrDefaultAsync();
                
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

        public async Task<string?> GetLastCodigoReservaAsync()
        {
            var ultimaReserva = await All<Reserva>()
                .OrderByDescending(r => r.ID_RESERVA).FirstOrDefaultAsync();

            return ultimaReserva?.ID_RESERVA;
        }

        public async Task<t01_orden_de_hospedaje> AddOrdenHospedajeAsync(t01_orden_de_hospedaje ordenDeHospedaje)
        {
            await InsertAsync(ordenDeHospedaje);
            await _context.SaveChangesAsync();
            return ordenDeHospedaje;
        }

        public async Task<ConsultaHuespedDetalle> GetOrdenDeHospedajeXDNI(string DNI)
        {
            return await (from h in _context.t04_huesped
                         join o in _context.t01_orden_de_hospedaje on h.ID_ORDEN_HOSPEDAJE equals o.ID_ORDEN_HOSPEDAJE
                         join c in _context.t03_cliente on o.ID_CLIENTE equals c.ID_CLIENTE
                         join r in _context.t02_habitaciones on o.ID_HABITACION equals r.ID_HABITACION
                         where c.DNI == DNI && o.ESTADO == "Finalizado"// Reemplaza el DNI según sea necesario
                         select new ConsultaHuespedDetalle
                         {
                             NombreHuesped = h.NOMBRE_HUESPED,
                             ApellidoHuesped = h.APELLIDO_HUESPED,
                             NroOrdenHospedaje = o.ID_ORDEN_HOSPEDAJE,
                             FechaIngreso = o.FECHA_INGRESO,
                             FechaSalida = o.FECHA_SALIDA,
                             NumeroHabitacion = r.NRO_HABITACION,
                             TipoHabitacion = r.TIPO,

                         }).FirstOrDefaultAsync();
        }

        public async Task<List<ConsultarCatalogoXTipo>> GetObtenerCatalogoXTipo(int a)
        {
            return await (from s in _context.t06_catalogo_servicios
                          join t in _context.t07_tipo_servicio on s.ID_TIPO_SERVICIO equals t.ID_TIPO_SERVICIO
                          where s.ID_TIPO_SERVICIO == a // Reemplaza el DNI según sea necesario
                          select new ConsultarCatalogoXTipo
                          {
                              IdServicio = s.ID_SERVICIO,
                              NombreServicio = s.NOMBRE_SERVICIO,
                              DescripcionServicio= s.DESCRIPCION_SERVICIO,
                              PrecioServicio= s.PRECIO_SERVICIO,

                          }).ToListAsync();
        }

        public async Task<List<t07_tipo_servicio>> GetTipoServicio()
        {
            return await All<t07_tipo_servicio>().ToListAsync();

        }

        public async Task<t05_orden_de_servicios> AddOrdenServicioAsync(t05_orden_de_servicios ordenServicio)
        {
            await InsertAsync(ordenServicio);
            await _context.SaveChangesAsync();
            return ordenServicio;
        }

        /*public async Task<Reserva> GetReservaXDNI(string dni)
        {
            return await All<Reserva>().AsNoTracking()
                .Where(reserva => reserva.DNI_CLIENTE == dni).FirstOrDefaultAsync();
        }*/

    }
}
