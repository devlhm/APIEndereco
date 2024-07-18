namespace APIEndereco.Domain
{
    public class CepValidator : ICepValidator
    {
        public bool IsValid(string cep)
        {
            if (cep.Length != 8 || !cep.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
