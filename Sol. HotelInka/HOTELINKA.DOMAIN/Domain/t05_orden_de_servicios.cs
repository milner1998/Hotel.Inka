using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class t05_orden_de_servicios : Entity
    {
        public int ID_ORDEN_SERVICIO { get; set; }

        public string ID_ORDEN_HOSPEDAJE { get; set; }

        public string ID_SERVICIO { get; set; }

        public DateTime FECHA_SOLICITUD { get; set; }

        public string ESTADO { get; set; }
    }
}
