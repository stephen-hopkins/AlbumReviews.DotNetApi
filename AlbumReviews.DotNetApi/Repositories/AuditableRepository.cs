using AlbumReviews.DotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.DotNetApi.Repositories;

public class AuditableRepository<T> : IAuditableRepository<T> where T: Auditable
{
    private readonly ApplicationContext context;
    protected DbSet<T> entities;

    public AuditableRepository(ApplicationContext context)
    {
        this.context = context;
        this.entities = this.context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return entities.AsEnumerable();
    }

    public Task<T?> Get(long id)
    {
        return entities.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(T entity, string userId)
    {
        if (entity.Id != 0)
        {
            throw new Exception("Error: Attempt to insert entity with existing id");
        }

        entity.LastUpdatedByUserId = userId;
        entity.CreatedDateTimeUtc = DateTime.UtcNow;
        entity.UpdatedDateTimeUtc = entity.CreatedDateTimeUtc;
        entities.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(T entity, string userId)
    {
        if (entity.Id == 0)
        {
            throw new Exception("Error: Attempt to update entity without existing id");
        }
        
        entity.UpdatedDateTimeUtc = DateTime.UtcNow;
        entity.LastUpdatedByUserId = userId;
        entities.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        entities.Remove(entity);
        await context.SaveChangesAsync();
    }
}