using APIEndereco.Domain;

namespace APIEndereco.Application
{
    public interface ICorreiosClient
    {
        Task<Address> GetAddressByCep(string cep);
    }
}
