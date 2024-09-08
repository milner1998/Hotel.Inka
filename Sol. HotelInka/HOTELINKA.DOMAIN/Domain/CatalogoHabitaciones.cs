using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.Domain
{
    public class CatalogoHabitaciones : Entity
    {
        public int ID_HABITACION { get; set; }

        public string NUM_HABITACION { get; set; }

        public string TIPO_HABITACION { get; set; }

        public int CAPACIDAD { get; set; }

        public decimal PRECIOXNOCHE { get; set; }

        public string DESCRIPCION_HABITACION { get; set; }

        public string ESTADO_HABITACION { get; set; }
    }
}
