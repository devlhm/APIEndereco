using APIEndereco.Application;
using APIEndereco.Domain;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace APIEndereco.Infrastructure
{
    public class AdressRepository : IAdressRepository
    {
        private readonly IConfiguration _configuration;

        public AdressRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Adress> GetByCep(string cep)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(
                _configuration.GetConnectionString("DBConnection"));
            return await connection.GetAsync<Adress>(cep);
        }

        public async void Save(Adress adress)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(
                _configuration.GetConnectionString("DBConnection"));
           await connection.InsertAsync(adress);

        }
    }
}
