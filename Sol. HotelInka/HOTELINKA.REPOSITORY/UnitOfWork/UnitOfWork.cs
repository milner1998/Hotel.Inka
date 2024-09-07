using HOTELINKA.REPOSITORY.Context;
using System.Threading.Tasks;

namespace HOTELINKA.REPOSITORY.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private HotelInkaContext _context;
        public UnitOfWork(HotelInkaContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        #region Save Changes

        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
