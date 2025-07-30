using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }
        public DbSet<Admin> Admins { set; get; }
        public DbSet<Car> Cars { set; get; }
        public DbSet<Repository> Repositories { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Car>().HasData(
                new Car { CarId = 1, Make = "Mercedec", Model = "G_CLASS", Year = 2013, Price = 500000 },
                new Car { CarId = 2, Make = "Mercedec", Model = "G_CLASS", Year = 2013, Price = 500000 },
                new Car { CarId = 3, Make = "Mercedec", Model = "G_CLASS", Year = 2013, Price = 500000  },
                new Car { CarId = 4, Make = "Mercedec", Model = "G_CLASS", Year = 2013, Price = 500000  }

            );

            modelBuilder.Entity<Admin>().HasData(
               new Admin
               {
                   Id= 1,
                   Email = "Riham@gmail.com",
                   Name= "Riham",
                   Password = "1234",
                   
               },
             new Admin
             {
                 Id = 2,
                 Email = "Hamsa@gmail.com",
                 Name = "Hamsa",
                 Password = "5678",

             },
              new Admin
              {
                  Id = 3,
                  Email = "Areen@gmail.com",
                  Name = "Areen",
                  Password = "9123",

              }
           );

            modelBuilder.Entity<Repository>().HasData(
             new Repository
             {
                 Id = 1,
                 AdminId = 1,
                 CarId = 1,
                 Make = "Mercedece",
                 ActionDate = DateTime.Now,
             },
            new Repository
             {
             Id = 2,
             AdminId = 2,
             CarId = 2,
             Make = "Mercedece",
             ActionDate = DateTime.Now,
             },
             new Repository
             {
                 Id = 3,
                 AdminId = 3,
                 CarId = 3,
                 Make = "Mercedece",
                 ActionDate = DateTime.Now,
             }
         );

        } 
    }

}
