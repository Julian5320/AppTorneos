using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppTorneos.Models
{
    public class Inscrito
    {
        [Key]
        public int id { get; set; }
        public string equipo { get; set; }
        public string torneo { get; set; }
    }
}