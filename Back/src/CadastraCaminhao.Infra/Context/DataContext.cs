using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CadastraCaminhao.Infra
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.MapTruck(modelBuilder);
            this.MapTruck(modelBuilder);
        }
    }
}
