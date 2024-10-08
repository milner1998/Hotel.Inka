using System;

namespace HOTELINKA.DOMAIN.Domain
{
    public class Reserva : Entity
    {
        public string ID_RESERVA { get; set; }

        public int ID_HUESPED { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        public DateTime FECHA_SALIDA { get; set; }

        public string TIPOHABITACION { get; set; }

        public string DESCRIPCION { get; set; }

        public int CAPACIDAD { get; set; }

        public string ESTADO_RESERVA { get; set; }
 

    }
}
