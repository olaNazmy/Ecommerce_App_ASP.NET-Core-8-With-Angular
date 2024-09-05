using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Interfaces
{
    public interface IUnitOfWork
    {
        //will contain all interfaces i have
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }  


    }
}
