using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTorneos.Models.ViewModel
{
    public class EquiposYTorneos
    {
        public List<Equipo> equipos { get; set; }
        public List<Torneo> torneos { get; set; }
        public string equipo { get; set; }
        public string torneo { get; set; }
    }
}