using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //CRUD operations
        Task<IReadOnlyList<T>> GetAllAsync();
        IEnumerable<T> GetAll(); 
        Task<T>  GetAsync(T id);
        Task AddAsync(T entity);
        Task UpdateAsync(T id,T entity);
        Task DeleteAsync(T id);



    }
}
