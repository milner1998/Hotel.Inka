using System.Threading.Tasks;

namespace HOTELINKA.REPOSITORY.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();

        void BeginTransaction();
        Task BeginTransactionAsync();
    }
}
