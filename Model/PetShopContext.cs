using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Update-Database -Verbose -Force -AppDomainBaseDirectory "C:\Path\To\bin"

namespace Model
{
    public class PetShopContext : DbContext
    {
            


        //TABLAS
        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Animal> Animales { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Raza> Razas { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public PetShopContext()
            : base("PetShopContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Eliminar convención de pluralización de nombres de tablas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Mascota>().ToTable("Mascotas");
            //modelBuilder.Entity<Mascota>()
            //            .Property(p => p.FechaNacimiento)
            //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<>()
            //            .Property(p => p.)
            //            .HasColumnName("");
            //modelBuilder.Entity<>()
            //            .HasRequired(p => p.)
            //            .WithMany(p => p.)
            //            .HasForeignKey(p => p.);
        }

        //public System.Data.Entity.DbSet<WebPetShop.Models.MascotaViewModel> MascotaViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebPetShop.Models.MascotaViewModel> MascotaViewModels { get; set; }



    }
}
