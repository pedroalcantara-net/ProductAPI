using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Products.API.Middleware;
using Products.Domain;
using Products.Repository;
using Products.Repository.Interface;
using Products.Service;
using Products.Service.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProductsContext>(options => options.UseSqlite(connString));
#endregion

builder.Services.AddTransient<ErrorHandlingMiddleware>();

#region Repository Dependency Injection
builder.Services.AddTransient<IProductRepository, ProductRepository>();
#endregion

#region Service Dependency Injection
builder.Services.AddTransient<IProductService, ProductService>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
