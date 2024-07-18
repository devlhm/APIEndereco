using APIEndereco.Domain;
using APIEndereco.Domain.Exceptions;
namespace APIEndereco.Application
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICorreiosClient _correiosClient;

        public AddressService(IAddressRepository addressRepository, ICorreiosClient correiosClient)
        {
            _addressRepository = addressRepository;
            _correiosClient = correiosClient;
        }

        public async Task<Address?> GetByCep(string cep)
        {

            string formattedCep = CepFormatter.Format(cep);
            Console.WriteLine(formattedCep);

            Address? address;
            address = await _addressRepository.GetByCep(formattedCep);

            if (address == null) throw new NotFoundException("Address not found in database");

            return address;
        }

        public async Task CreateByCep(string cep)
        {
            Address address;
            address = await _correiosClient.GetAddressByCep(cep);

            await _addressRepository.Create(address);
        }
    }
}
