using APIEndereco.Domain;

namespace APIEndereco.Application
{
    public interface ICorreiosClient
    {
        Task<Adress> GetAdressByCep(string cep);
    }
}
