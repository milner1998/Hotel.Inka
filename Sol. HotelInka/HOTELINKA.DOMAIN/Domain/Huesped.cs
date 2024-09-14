using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class Huesped : Entity
    {
        public int ID_HUESPED { get; set; }

        public string DNI_CLIENTE { get; set; }

        public string NOMBRE_CLIENTE { get; set; }

        public string APELLIDO_CLIENTE { get; set; }

        public string CORREO_ELECTRONICO { get; set; }

        public string TELEFONO_CLIENTE { get; set; }
    }
}
