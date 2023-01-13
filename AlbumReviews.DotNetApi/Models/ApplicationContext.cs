using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.DotNetApi.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<AlbumReview> AlbumReviews => Set<AlbumReview>();
}