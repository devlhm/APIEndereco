using APIEndereco.Domain;

namespace APIEndereco.Application
{
    public interface IAddressRepository
    {
        Task<Address?> GetByCep(string cep);
        Task Create(Address address);
    }
}
