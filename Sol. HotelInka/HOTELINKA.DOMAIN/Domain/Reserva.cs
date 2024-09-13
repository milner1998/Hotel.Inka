using System;

namespace HOTELINKA.DOMAIN.Domain
{
    public class Reserva : Entity
    {
        public int ID_RESERVA { get; set; }

        public string DNI_CLIENTE { get; set; }

        public string NOMBRE_CLIENTE { get; set; }

        public string APELLIDO_CLIENTE { get; set; }

        public string CORREO_ELECTRONICO { get; set; }

        public string TELEFONO_CLIENTE { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        public DateTime FECHA_SALIDA { get; set; }

        public string TIPOHABITACION { get; set; }

        public string DESCRIPCION { get; set; }

        public int CAPACIDAD { get; set; }

        public string ESTADO_RESERVA { get; set; }
 

    }
}
