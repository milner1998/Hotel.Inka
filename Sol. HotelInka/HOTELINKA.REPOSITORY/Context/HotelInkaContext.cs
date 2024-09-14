using HOTELINKA.DOMAIN.Domain;
using Microsoft.EntityFrameworkCore;

namespace HOTELINKA.REPOSITORY.Context
{
    public class HotelInkaContext : DbContext
    {
        public HotelInkaContext(DbContextOptions<HotelInkaContext> options) : base(options)
        {
        }

        #region DBSET

        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<CatalogoHabitaciones> CatalogoHabitaciones { get; set; }

        public DbSet<OrdenDeHospedaje> OrdenDeHospedaje { get; set; }

        public DbSet<Huesped> Huesped { get; set; }

        #endregion 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region TABLES

            builder.Entity<Reserva>()
               .HasKey(o => new { o.ID_RESERVA });

            builder.Entity<CatalogoHabitaciones>()
                .HasKey(o => new { o.ID_HABITACION});

            builder.Entity<OrdenDeHospedaje>()
                .HasKey(o => new { o.Id_OrdenDeHospedaje });

            builder.Entity<Huesped>()
   .             HasKey(o => new { o.ID_HUESPED });


            DbSeed(builder);

            base.OnModelCreating(builder);

            #endregion
        }

        protected virtual void DbSeed(ModelBuilder builder) { }
    }
}
