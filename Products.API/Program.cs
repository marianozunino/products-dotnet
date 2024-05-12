using Products.API.Middlewares;
using Scalar.AspNetCore;
using Products.Business.Persistence;
using Products.Business.Repository;
using Products.Business.Service;

namespace Products.API;


internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var corsPolicyName = "MyAllowSpecificOrigins";

// Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        builder.Services.AddCors(
            options =>
            {
                options.AddPolicy(
                    corsPolicyName,
                    corsPolicyBuilder => corsPolicyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.ConfigureExceptionHandler();
        app.UseCors(corsPolicyName);

        app.MapControllers();

        app.Run();
    }
}
