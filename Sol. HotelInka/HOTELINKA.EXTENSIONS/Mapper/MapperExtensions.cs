using AutoMapper;
using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;

namespace HOTELINKA.EXTENSIONS.Mapper
{
    public class MapperExtensions : Profile
    {
        public MapperExtensions()
        {
            CreateMap<RegistrarReservaRequest, Reserva>().AfterMap((src, dst) =>
            {
                dst.DNI_CLIENTE = src.DniCliente;
                dst.NOMBRE_CLIENTE = src.NombreCliente;
                dst.APELLIDO_CLIENTE = src.ApellidoCliente.Trim();
                dst.CORREO_ELECTRONICO = src.CorreoElectronico.Trim() ?? string.Empty;
                dst.TELEFONO_CLIENTE = src.TelefonoCliente;
                dst.FECHA_INGRESO = src.FechaIngreso;
                dst.FECHA_SALIDA  = src.FechaSalida;
                dst.ESTADO_RESERVA = "Activo";
                dst.FECHA_REGISTRO = DateTime.Now;
            });

            CreateMap<Reserva, ResponseDTO>().AfterMap((src, dst) =>
            {
                dst.Success = true;
                dst.TitleMessage = "Éxito";
                dst.Message = "Su reserva ha sido generada correctamente";
                dst.Id = src.ID;
            });

        }
    }
}
