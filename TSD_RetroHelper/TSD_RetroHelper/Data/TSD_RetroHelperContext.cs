﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TSD_RetroHelper.Models
{
    public class TSD_RetroHelperContext : DbContext
    {
        public TSD_RetroHelperContext (DbContextOptions<TSD_RetroHelperContext> options)
            : base(options)
        {
        }

        public DbSet<TSD_RetroHelper.Models.RetroItem> RetroItem { get; set; }
    }
}
