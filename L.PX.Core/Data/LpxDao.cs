﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace L.PX.Core.Data
{
    public class LpxDao : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Participante> Participantes { get; set; }
    }

}
