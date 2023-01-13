using System.Data.Common;
using AlbumReviews.DotNetApi.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.UnitTest.Helpers;

public class SqlLiteContext : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<ApplicationContext> _contextOptions;

    public SqlLiteContext()
    {
        // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
        // at the end of the test (see Dispose below).
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        
        // These options will be used by the context instances in this test suite, including the connection opened above.
        _contextOptions = new DbContextOptionsBuilder<ApplicationContext>()
            .UseSqlite(_connection)
            .Options;
        
        using var context = new ApplicationContext(_contextOptions);
        context.Database.EnsureCreated();
    }

    public void Dispose() => _connection.Dispose();

    protected ApplicationContext CreateContext() => new(_contextOptions);
}