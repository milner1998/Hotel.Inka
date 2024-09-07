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

        public DbSet<Reserva> Deuda { get; set; }

        #endregion 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region TABLES

            builder.Entity<Reserva>()
               .HasKey(o => new { o.ID });
 
             
            DbSeed(builder);

            base.OnModelCreating(builder);

            #endregion
        }

        protected virtual void DbSeed(ModelBuilder builder) { }
    }
}
