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
        Task<List<T>> GetAllAsync();
        IEnumerable<T> GetAll(); 
        Task<T>  GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id,T entity);
        Task DeleteAsync(int id);



    }
}
