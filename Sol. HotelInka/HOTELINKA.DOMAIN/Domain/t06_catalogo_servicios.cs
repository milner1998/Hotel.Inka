using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class t06_catalogo_servicios : Entity
    {
        public string ID_SERVICIO { get; set; }

        public int ID_TIPO_SERVICIO { get; set; }

        public string NOMBRE_SERVICIO { get; set; }

        public string DESCRIPCION_SERVICIO { get; set; }

        public decimal PRECIO_SERVICIO { get; set; }

    }
}
