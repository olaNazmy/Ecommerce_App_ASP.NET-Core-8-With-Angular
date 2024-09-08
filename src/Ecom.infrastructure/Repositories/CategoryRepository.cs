using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        //reference from context
        public ApplicationDbContext context { get; }

        public CategoryRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }


        //public async Task<Category> GetAsync(int id)
        //{
        //    var result =  await context.Categories.FindAsync(id);
        //    return result;
        //}
    }
}
