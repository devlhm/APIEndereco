using APIEndereco.Application;
using APIEndereco.Domain;
using APIEndereco.Domain.Exceptions;
using Newtonsoft.Json;

namespace APIEndereco.Infrastructure
{
    public class CorreiosClient() : ICorreiosClient
    {
        public async Task<Address> GetAddressByCep(string cep)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json");
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();

            var error = JsonConvert.DeserializeAnonymousType(jsonString, new { erro = false });
            if(error != null && error.erro) throw new NotFoundException("CEP doesn't exist");


            Address? address = JsonConvert.DeserializeObject<Address>(jsonString);
            if (address == null) throw new Exception("Error while deserializing JSON from Correios API");

            return address;
        }
    }
}
