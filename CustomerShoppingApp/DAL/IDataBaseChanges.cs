using System.Linq;
using System.Threading.Tasks;

namespace CustomerShoppingApp.DAL
{
    public interface IDataBaseChanges
    {
        Task AddAsync<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        IQueryable<T> Query<T>() where T : class;
        Task CommitAsync();
        void Attach<T>(T obj) where T : class;
        void Dispose();
        void Remove<T>(T obj) where T : class;
    }
}
