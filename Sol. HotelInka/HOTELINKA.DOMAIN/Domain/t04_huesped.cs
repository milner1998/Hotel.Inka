using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class t04_huesped : Entity
    {
        public string ID_HUESPED { get; set; }

        public string ID_ORDEN_HOSPEDAJE { get; set; }

        public string DNI_HUESPED { get; set; }

        public string NOMBRE_HUESPED { get; set; }

        public string APELLIDO_HUESPED { get; set; }

    }
}
