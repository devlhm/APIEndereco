using APIEndereco.Domain;

namespace APIEndereco.Application
{
    public interface IAddressService
    {
        Task<Address?> GetByCep(string cep);
        Task CreateByCep(String cep);
    }
}
