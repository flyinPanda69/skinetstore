using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntities
    {
        public StoreContext _context { get; }
        public GenericRepository(StoreContext context)
        {
            _context = context;
            
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsnc()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T>spec)
        {
            return SpecificationEvaulator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}