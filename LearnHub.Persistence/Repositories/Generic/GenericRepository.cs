using LearnHub.Application.Contracts.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Persistence.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context_En _context;
        private DbSet<T> table;
        public GenericRepository(Context_En context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _context.BulkInsertAsync(new List<T> { entity });
        }

        public async Task Delete(List<int> ids)
        {
            var entities = new List<T>();

            foreach (var id in ids)
            {
                var entity = await Get(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with ID {id} not found.");
                }

                entities.Add(entity);
            }

            await _context.BulkDeleteAsync(entities);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity != null;
        }

        public async Task<T?> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            await _context.BulkUpdateAsync(new List<T> { entity });
        }
    }
}
