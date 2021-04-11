using CadastraCaminhao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastraCaminhao.Infra.Mapping
{
    public static class MapTruckContext
    {
        public static void MapTruck(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>().ToTable("tabTruck");

            modelBuilder.Entity<Truck>().Property(x => x.Id).HasColumnType("varchar(50)");
            modelBuilder.Entity<Truck>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Truck>().HasKey(x => x.Id);
            modelBuilder.Entity<Truck>().HasIndex(x => x.Id);

            modelBuilder.Entity<Truck>().Property(x => x.Model).HasColumnType("varchar(2)");
            modelBuilder.Entity<Truck>().Property(x => x.Model).HasColumnName("model");
            modelBuilder.Entity<Truck>().Property(x => x.Model).IsRequired();

            modelBuilder.Entity<Truck>().Property(x => x.YearOfManufacture).HasColumnType("int(4)");
            modelBuilder.Entity<Truck>().Property(x => x.YearOfManufacture).HasColumnName("yearOfManufacture");
            modelBuilder.Entity<Truck>().Property(x => x.YearOfManufacture).IsRequired();

            modelBuilder.Entity<Truck>().Property(x => x.ModelYear).HasColumnType("int(4)");
            modelBuilder.Entity<Truck>().Property(x => x.ModelYear).HasColumnName("modelYear");
            modelBuilder.Entity<Truck>().Property(x => x.ModelYear).IsRequired();


            modelBuilder.Entity<Truck>().Property(x => x.Color).HasColumnType("varchar(20)");
            modelBuilder.Entity<Truck>().Property(x => x.Color).HasColumnName("color");

            modelBuilder.Entity<Truck>().Property(x => x.Image).HasColumnType("varchar(80)");
            modelBuilder.Entity<Truck>().Property(x => x.Image).HasColumnName("image");

        }
    }
}
