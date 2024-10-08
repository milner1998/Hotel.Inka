using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class t03_cliente : Entity
    {
        public string ID_CLIENTE { get; set; }

        public string NOMBRE { get; set; }

        public string APELLIDO { get; set; }

        public string DNI { get; set; }

        public string TELEFONO { get; set; }

        public string email { get; set; }
    }
}
