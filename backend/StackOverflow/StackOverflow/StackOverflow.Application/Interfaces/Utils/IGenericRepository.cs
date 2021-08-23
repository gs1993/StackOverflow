using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflow.Application.Interfaces.Utils
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyList<T>> GetPagedReponse(int pageNumber, int pageSize);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
