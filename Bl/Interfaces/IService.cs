using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bl.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Insert(T reg);
        Task Update(T reg);
        Task Delete(int id);
        Task Delete(T reg);
    }
}
