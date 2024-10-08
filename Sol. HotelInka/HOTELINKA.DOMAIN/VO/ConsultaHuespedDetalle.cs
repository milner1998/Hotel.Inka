using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELINKA.DOMAIN.VO
{
    public class ConsultaHuespedDetalle
    {
        public string NombreHuesped { get; set; }

        public string ApellidoHuesped { get; set; }

        public string NroOrdenHospedaje { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaSalida { get; set; }

        public int NumeroHabitacion { get; set; }

        public string TipoHabitacion { get; set; }

    }
}
