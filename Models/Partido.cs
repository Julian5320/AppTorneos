using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppTorneos.Models
{
    public class Partido
    {
        [Key]
        public int id { get; set; }
        public string equipoUno { get; set; }
        public string equipoDos { get; set; }
        public DateTime horaUno { get; set; }
        public DateTime horaDos { get; set; }
        public string grupo { get; set; }
    }
}