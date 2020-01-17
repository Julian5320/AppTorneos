using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppTorneos.Models
{
    public class MarcadorUser
    {
        [Key]
        public int id { get; set; }
        public ApplicationUser id_user { get; set; }
        public Partido id_partido { get; set; }
        public Torneo id_torneo { get; set; }
        public int resultadoUno { get; set; }
        public int resultadoDos { get; set; }

    }
}