﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppTorneos.Models
{
    public class Empresa
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }

        public string id_Usuario { get; set; }
    }
}