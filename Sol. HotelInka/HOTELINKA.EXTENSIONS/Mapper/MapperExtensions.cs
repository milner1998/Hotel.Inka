using AutoMapper;
using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;
using HOTELINKA.DTO.Reserva.Response;

namespace HOTELINKA.EXTENSIONS.Mapper
{
    public class MapperExtensions : Profile
    {
        public MapperExtensions()
        {
            CreateMap<RegistrarReservaRequest, Reserva>().AfterMap((src, dst) =>
            {
                /*dst.DNI_CLIENTE = src.DniCliente;
                dst.NOMBRE_CLIENTE = src.NombreCliente;
                dst.APELLIDO_CLIENTE = src.ApellidoCliente.Trim();
                dst.CORREO_ELECTRONICO = src.CorreoElectronico.Trim() ?? string.Empty;
                dst.TELEFONO_CLIENTE = src.TelefonoCliente;*/
                dst.FECHA_INGRESO = DateTime.UtcNow;
                dst.FECHA_SALIDA  = DateTime.UtcNow;
                dst.ESTADO_RESERVA = "Pagado";
            });

            CreateMap<Reserva, ResponseDTO>().AfterMap((src, dst) =>
            {
                dst.Success = true;
                dst.TitleMessage = "Éxito";
                dst.Message = "Su reserva ha sido generada correctamente";
                dst.Id = src.ID_RESERVA;
            });

            CreateMap<CatalogoHabitaciones, ObtenerCalogoHabitacionesDTO>().AfterMap((src, dst) =>
            {
                dst.id_Habitacion = src.ID_HABITACION;
                dst.num_Habitacion = src.NUM_HABITACION;
                dst.Tipo_Habitacion = src.TIPO_HABITACION;
                dst.Capacidad = src.CAPACIDAD;
                dst.PRECIOXNOCHE = src.PRECIOXNOCHE;
                dst.DESCRIPCION_HABITACION = src.DESCRIPCION_HABITACION;
                dst.ESTADO_HABITACION = "Disponible";
            });

            CreateMap<Reserva, ObtenerReservaxDNI>().AfterMap((src, dst) =>
            {
                dst.IdReserva = src.ID_RESERVA;
                dst.IdHuesped = src.ID_HUESPED;
                dst.FechaIngreso = src.FECHA_INGRESO;
                dst.FechaSalida = src.FECHA_SALIDA;
                dst.TipoHabiracion = src.TIPOHABITACION;
                dst.Descripcion = src.DESCRIPCION;
                dst.Capacidad = src.CAPACIDAD;
                dst.EstadoHabitacion = src.ESTADO_RESERVA;
            });


            CreateMap<Huesped, ObtenerClientePorDNIDTO>().AfterMap((src, dst) =>
            {
                dst.IdHuesped = src.ID_HUESPED;
                dst.dniCliente = src.DNI_CLIENTE;
                dst.NomCliente = src.NOMBRE_CLIENTE;
                dst.ApeCliente = src.APELLIDO_CLIENTE.Trim();
                dst.telefonoCliente = src.TELEFONO_CLIENTE;
                dst.correoCliente = src.CORREO_ELECTRONICO.Trim() ?? string.Empty;
            });

           CreateMap<RegistrarOrdenHospedaje, OrdenDeHospedaje>().AfterMap((src, dst) =>
            {
                dst.Id_OrdenDeHospedaje = src.IdOrdenHodepaje;
                //dst.Id_Reserva = src.IdReserva;
                //dst.Id_Habitacion = src.IdHabitacion;
                dst.fecha_inicio = src.FechaInicio;
                dst.fecha_fin = DateTime.UtcNow;
                dst.Total_Pago = src.TotalPago;
                dst.Estado_OrdenDeHospedaje = "Pen pago Caja";
            });

            CreateMap<OrdenDeHospedaje, ResponseDTO>().AfterMap((src, dst) =>
            {
                dst.Success = true;
                dst.TitleMessage = "Éxito";
                dst.Message = "Su Orden De Hospedaje ha sido generada correctamente";
                dst.Id = src.Id_OrdenDeHospedaje;
            });

            /*CreateMap<Reserva, ObtenerReservaDTO>().AfterMap((src, dst) =>
            {
                dst.TipoHabitacion = src.TIPOHABITACION;
                dst.Descripcion = src.DESCRIPCION;
                dst.Capacidad = src.CAPACIDAD;
            });*/

        }
    }
}
