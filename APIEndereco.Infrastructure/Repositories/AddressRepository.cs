using APIEndereco.Application;
using APIEndereco.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace APIEndereco.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IConfiguration _configuration;

        public AddressRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Address?> GetByCep(string cep)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(
                   _configuration.GetConnectionString("DBConnection"));
                return await connection.QuerySingleOrDefaultAsync<Address>($"SELECT * FROM address WHERE cep='{cep}'");
            }
            catch(Exception e)
            {
                throw new Exception($"Error while accessing database: {e.Message}");
            }
        }

        public async Task Create(Address address)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(
                    _configuration.GetConnectionString("DBConnection"));
                await connection.ExecuteAsync($"INSERT INTO address (cep, logradouro, complemento, bairro, localidade, uf, ibge, gia, ddd, siafi) VALUES (@Cep, @Logradouro, @Complemento, @Bairro, @Localidade, @Uf, @Ibge, @Gia, @Ddd, @Siafi)", address);
            }
            catch(Exception e)
            {
                throw new Exception($"Error while accessing database: {e.Message}");
            }
        }
    }
}