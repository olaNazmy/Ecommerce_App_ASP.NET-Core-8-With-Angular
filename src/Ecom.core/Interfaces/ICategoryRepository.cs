using Ecom.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //custom function take int 
        //Task<Category> GetAsync(int id);
    }
}
