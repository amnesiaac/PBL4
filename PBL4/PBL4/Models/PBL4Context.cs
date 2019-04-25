﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PBL4.Models
{
    public class PBL4Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PBL4Context() : base("name=PBL4Context")
        {
        }

        public System.Data.Entity.DbSet<PBL4.Models.Evento> Eventoes { get; set; }

        public System.Data.Entity.DbSet<PBL4.Models.Ingresso> Ingressoes { get; set; }

        public System.Data.Entity.DbSet<PBL4.Models.Pessoa> Pessoas { get; set; }

        public System.Data.Entity.DbSet<PBL4.Models.Bilheteria> Bilheterias { get; set; }

        public System.Data.Entity.DbSet<PBL4.Models.VendaIngresso> VendaIngressoes { get; set; }
    }
}
