using APIEndereco.Application;
using APIEndereco.Domain;
using Newtonsoft.Json;

namespace APIEndereco.Infrastructure
{
    public class CorreiosClient() : ICorreiosClient
    {
        public async Task<Adress> GetAdressByCep(string cep)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json");
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();

            Adress? adress = JsonConvert.DeserializeObject<Adress>(jsonResponse);

            if(adress == null) throw new Exception("Error while deserializing JSON");

            return adress;

        }
    }
}
