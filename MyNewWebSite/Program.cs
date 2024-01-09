using Microsoft.EntityFrameworkCore;
using MyNewWebSite.AccessLayer.Context;
using MyNewWebSite.Core.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MyDatabaseContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("connLite"));
});

builder.Services.AddAutoMapper(typeof(MyDatabaseProfile));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

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

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MyDatabaseContext>();
await context.Database.MigrateAsync();

app.Run();
