using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppTorneos.Models
{
    public class Torneo
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }
    }
}