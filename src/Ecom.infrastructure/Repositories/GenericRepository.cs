using Ecom.core.Interfaces;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext _context)
        {
            context = _context; 
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll() => context.Set<T>().AsNoTracking().ToList();

        public async Task<List<T>> GetAllAsync() => await context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetAsync(int id) => await context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(int id, T entity)
        {
            var foundEntity = await context.Set<T>().FindAsync(id);
            context.Update(foundEntity);
            context.SaveChangesAsync();

        }
    }
}
