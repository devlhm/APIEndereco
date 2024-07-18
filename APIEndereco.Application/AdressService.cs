using APIEndereco.Domain;
namespace APIEndereco.Application
{
    public class AdressService : IAdressService
    {
        private readonly IAdressRepository _adressRepository;

        // posso so deixar estatico?
        private readonly ICepValidator _cepValidator;
        private readonly ICepFormatter _cepFormatter;

        private readonly ICorreiosClient _correiosClient;

        public AdressService(IAdressRepository adressRepository, ICepValidator cepValidator, ICorreiosClient correiosClient, ICepFormatter cepFormatter)
        {
            _adressRepository = adressRepository;
            _cepValidator = cepValidator;
            _correiosClient = correiosClient;
            _cepFormatter = cepFormatter;
        }

        public async Task<Adress> GetByCep(string cep)
        {
            if (!_cepValidator.IsValid(cep))
            {
                throw new FormatException("CEP invalido!");
            }

            string formattedCep = _cepFormatter.Format(cep);

            try
            {
                return await _adressRepository.GetByCep(formattedCep);
            } catch(Exception e)
            {
                throw new Exception("Error while accessing database", e);
            }
        }

        public async void SaveByCep(string cep)
        {
            if (!_cepValidator.IsValid(cep))
            {
                throw new FormatException("CEP invalido!");
            }

            Adress adress;

            try { 
               adress  = await _correiosClient.GetAdressByCep(cep);
            } catch(Exception e)
            {
                throw new Exception("Error while accessing Correios API", e);
            }

            try
            {
                _adressRepository.Save(adress);
            } catch(Exception e)
            {
                throw new Exception("Error while accessing database", e);
            }
        }
    }
}
