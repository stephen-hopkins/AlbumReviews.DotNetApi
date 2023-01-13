using System.Reflection;
using AlbumReviews.DotNetApi.Models;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

// Add autofac DI
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    var assembly = Assembly.GetExecutingAssembly();
    containerBuilder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Service"))
        .AsImplementedInterfaces();
});

// Add MySQL DB
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
if (connection == null)
{
    throw new Exception("No default connection string specified");
}
builder.Services.AddDbContext<ApplicationContext>(
    options => options
        .UseMySQL(connection)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();