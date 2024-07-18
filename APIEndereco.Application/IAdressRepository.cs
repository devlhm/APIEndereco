using APIEndereco.Domain;

namespace APIEndereco.Application
{
    public interface IAdressRepository
    {
        Task<Adress> GetByCep(string cep);
        void Save(Adress adress);
    }
}
