using APIEndereco.Domain;

namespace APIEndereco.Application
{
    public interface IAdressService
    {
        Task<Adress> GetByCep(string cep);
        void SaveByCep(String cep);
    }
}
