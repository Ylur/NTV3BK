using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolDB;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SchoolContext _context;
        protected readonly DbSet<T> _dbSet;
        
        public Repository(SchoolContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        
        public async Task<T> GetByIdAsync(params object[] id)
        {
            return await _dbSet.FindAsync(id);
        }
        
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        
        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        
        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
