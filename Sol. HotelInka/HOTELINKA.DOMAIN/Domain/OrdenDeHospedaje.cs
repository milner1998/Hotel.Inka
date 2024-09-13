using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class OrdenDeHospedaje : Entity
    {
        public int Id_OrdenDeHospedaje { get; set; }

        public string codigo_OrdenDeHospedaje { get; set; }

        //public int Id_Reserva { get; set; }

        //public int Id_Husped { get; set; }

        //public int Id_Habitacion { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public decimal Total_Pago { get; set; }

        public string Estado_OrdenDeHospedaje { get; set; }

    }
}
