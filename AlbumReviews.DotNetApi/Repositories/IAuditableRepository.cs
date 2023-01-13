using AlbumReviews.DotNetApi.Models;

namespace AlbumReviews.DotNetApi.Repositories;

public interface IAuditableRepository<T> where T : Auditable
{
    public IEnumerable<T> GetAll();
    public Task<T?> Get(long id);
    public Task Insert(T entity, string userId);
    public Task Update(T entity, string userId);
    public Task Delete(T entity);
}