using System;

namespace HOTELINKA.DOMAIN.Domain
{
    public class Reserva : Entity
    {
        public int ID { get; set; }

        public string CODIGO_RESERVA { get; set; }

        public string DNI_CLIENTE { get; set; }

        public string NOMBRE_CLIENTE { get; set; }

        public string APELLIDO_CLIENTE { get; set; }

        public string CORREO_ELECTRONICO { get; set; }

        public string TELEFONO_CLIENTE { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        public DateTime FECHA_SALIDA { get; set; }

        public string ESTADO_RESERVA { get; set; }

        public DateTime FECHA_RESERVA { get; set; }

        public DateTime FECHA_REGISTRO { get; set; }

        public DateTime FECHA_ACTUALIZACION { get; set; }

    }
}
