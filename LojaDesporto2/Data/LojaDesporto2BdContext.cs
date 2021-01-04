using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaDesporto2.Models;

namespace LojaDesporto2.Data
{
    public class LojaDesporto2BdContext : DbContext
    {
        public LojaDesporto2BdContext (DbContextOptions<LojaDesporto2BdContext> options)
            : base(options)
        {
        }

        public DbSet<LojaDesporto2.Models.Produto> Produto { get; set; }
    }
}
