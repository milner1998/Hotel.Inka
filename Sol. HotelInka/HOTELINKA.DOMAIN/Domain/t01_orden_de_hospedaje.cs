using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class t01_orden_de_hospedaje : Entity
    {
        public string ID_ORDEN_HOSPEDAJE { get; set; }

        /*public int Id_Reserva { get; set; }

        public int Id_Husped { get; set; }*/

        public string ID_CLIENTE { get; set; }

        public string ID_HABITACION { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        public DateTime FECHA_SALIDA { get; set; }

        //public decimal Total_Pago { get; set; }

        public string ESTADO { get; set; }

    }
}
