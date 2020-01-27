using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTorneos.Models.ViewModel
{
    public class Marcadoresusuarios
    {
        public int id { get; set; }
        public string id_user { get; set; }
        public string id_partido { get; set; }
        public string id_torneo { get; set; }
        public int resultadoUno { get; set; }
        public int resultadoDos { get; set; }
        public string equipoUno { get; set; }
        public string equipoDos { get; set; }
        public string torneo { get; set; }
        public DateTime horaUno { get; set; }
        public DateTime horaDos { get; set; }
        public string grupo { get; set; }

    }
}