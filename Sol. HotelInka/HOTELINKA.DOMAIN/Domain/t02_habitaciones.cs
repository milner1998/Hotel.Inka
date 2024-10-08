using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class t02_habitaciones :Entity
    {
        public string ID_HABITACION { get; set; }

        public int NRO_HABITACION { get; set; }

        public string ESTADO { get; set; }

        public string TIPO { get; set; }

    }
}
