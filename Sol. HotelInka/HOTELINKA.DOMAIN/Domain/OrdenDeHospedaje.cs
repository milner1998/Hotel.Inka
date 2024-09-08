using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class OrdenDeHospedaje
    {
        public int id_OrdenDeHospedaje { get; set; }

        public string codigo_OrdenDeHospedaje { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public double Total_Pago { get; set; }

        public string Estado_OrdenDeHospedaje { get; set; }

    }
}
