using APIEndereco.Application;
using APIEndereco.Infrastructure;
using APIEndereco.Infrastructure.Repositories;
using Npgsql;
using System.Data;

namespace APIEndereco.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<DataContext>();

            builder.Services.AddControllers();

            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<ICorreiosClient, CorreiosClient>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
           

            var app = builder.Build();
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                Task.Run(context.Init);
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
