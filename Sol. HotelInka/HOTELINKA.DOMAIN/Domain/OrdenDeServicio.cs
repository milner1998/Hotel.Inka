using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class OrdenDeServicio : Entity
    {
        public string ID_ORDEN_SERVICIO { get; set; }

        public string ID_ORDEN_HOSPEDAJE { get; set; }

        public DateTime FECHA_SOLICITUD { get; set; }

        public decimal MONTO_TOTAL { get; set; }

        public string ESTADO_ORDENSERVICIO { get; set; }
    }
}
