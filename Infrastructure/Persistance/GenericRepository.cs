using Core.Interfaces;
using Infrastructure.Data;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T>
    where T : class
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public bool EntityExists(int id)
    {
        return context.Set<T>().Find(id) != null;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<Option<T>> GetByIdAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return Option<T>.None;
        }
        return Option<T>.Some(entity);
    }

    public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async  Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        context.Set<T>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
    }
}
