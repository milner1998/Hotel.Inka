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

        public DbSet<t01_orden_de_hospedaje> t01_orden_de_hospedaje { get; set; }

        public DbSet<t02_habitaciones> t02_habitaciones { get; set; }

        public DbSet<t03_cliente> t03_cliente { get; set; }


        public DbSet<t04_huesped> t04_huesped { get; set; }

        public DbSet<t06_catalogo_servicios> t06_catalogo_servicios { get; set; }

        public DbSet<t07_tipo_servicio> t07_tipo_servicio { get; set; }

        #endregion 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region TABLES

            builder.Entity<Reserva>()
               .HasKey(o => new { o.ID_RESERVA });

            builder.Entity<CatalogoHabitaciones>()
                .HasKey(o => new { o.ID_HABITACION});

            builder.Entity<t01_orden_de_hospedaje>()
                .HasKey(o => new { o.ID_ORDEN_HOSPEDAJE });

            builder.Entity<t02_habitaciones>()
                .HasKey(o => new { o.ID_HABITACION });

            builder.Entity<t03_cliente>()
                .HasKey(o => new { o.ID_CLIENTE });

            builder.Entity<t04_huesped>()
                .HasKey(o => new { o.ID_HUESPED });

            builder.Entity<t06_catalogo_servicios>()
                .HasKey(o => new { o.ID_SERVICIO });

            builder.Entity<t07_tipo_servicio>()
                .HasKey(o => new { o.ID_TIPO_SERVICIO });


            DbSeed(builder);

            base.OnModelCreating(builder);

            #endregion
        }

        protected virtual void DbSeed(ModelBuilder builder) { }
    }
}
