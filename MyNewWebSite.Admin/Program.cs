using Microsoft.EntityFrameworkCore;
using MyNewWebSite.AccessLayer.Entity;
using MyNewWebSite.AccessLayer.DB;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
using var context = new MyWebSiteContext(builder.Configuration.GetSection("DbConnectionStrings").Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

bool recreateDb = builder.Configuration.GetValue<bool>("recreatedDb");
if (recreateDb)
{
    context.Database.EnsureDeletedAsync();
    context.Database.EnsureCreatedAsync();
}
context.Database.MigrateAsync();
app.UseAuthorization();

app.MapControllers();

app.Run();
