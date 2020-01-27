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
        public string id_user { get; set; }
        public int id_partido { get; set; }
        public string id_torneo { get; set; }
        public int resultadoUno { get; set; }
        public int resultadoDos { get; set; }

    }
}