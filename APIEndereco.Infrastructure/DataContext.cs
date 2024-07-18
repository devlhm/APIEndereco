

namespace APIEndereco.Infrastructure
{
    using System.Data;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Npgsql;

    public class DataContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Init()
        {

            var sql = """
                CREATE TABLE IF NOT EXISTS 
                address (
                    cep CHAR(9) NOT NULL PRIMARY KEY,
                    logradouro TEXT,
                    complemento TEXT,
                    unidade TEXT,
                    bairro TEXT,
                    localidade TEXT,
                    uf CHAR(2),
                    ibge CHAR(7),
                    gia VARCHAR(8),
                    ddd CHAR(2),
                    siafi CHAR(4)
                );
            """;

            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(
                    _configuration.GetConnectionString("DBConnection"));
                await connection.ExecuteAsync(sql);

            } catch(Exception e)
            {
                throw new Exception($"Error trying to create table: {e.Message}");
            }
        }
    }
}
