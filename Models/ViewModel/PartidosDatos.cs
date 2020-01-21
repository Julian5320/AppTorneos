using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTorneos.Models.ViewModel
{
    public class PartidosDatos
    {
        public List<Equipo> equipos { get; set; }
        public List<Torneo> torneos { get; set; }
        public int id { get; set; }
        public string equipoUno { get; set; }
        public string equipoDos { get; set; }
        public string torneo { get; set; }
        public DateTime horaUno { get; set; }
        public DateTime horaDos { get; set; }
        public string grupo { get; set; }
    }
}