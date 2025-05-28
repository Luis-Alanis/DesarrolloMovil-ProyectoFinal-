using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalDesarrolloMovil.Models;

namespace ProyectoFinalDesarrolloMovil.Models
{
    public class GastosDbContext : DbContext
    {
        public GastosDbContext(DbContextOptions<GastosDbContext> options) : base(options) { }

        public DbSet<Gasto> Gastos => Set<Gasto>();
    }
}
