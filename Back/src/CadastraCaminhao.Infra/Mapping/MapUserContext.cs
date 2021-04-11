using CadastraCaminhao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastraCaminhao.Infra.Mapping
{
    public static class MapUserContext
    {
        public static void MapUser(this DataContext context, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tabUser");

            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("idUser");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.Id);

            modelBuilder.Entity<User>().Property(x => x.Login).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.Login).HasColumnName("login");
            modelBuilder.Entity<User>().Property(x => x.Login).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Role).HasColumnType("varchar(50)");
            modelBuilder.Entity<User>().Property(x => x.Role).HasColumnName("role");
            modelBuilder.Entity<User>().Property(x => x.Role).IsRequired();
        }
    }
}