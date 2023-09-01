using Products.API.Middlewares;
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

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddDbContext<DataContext>();

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
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.ConfigureExceptionHandler();
        app.UseCors(corsPolicyName);

        app.MapControllers();

        app.Run();
    }
}