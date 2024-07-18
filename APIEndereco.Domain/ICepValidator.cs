namespace APIEndereco.Domain
{
    public interface ICepValidator
    {
        bool IsValid(string cep);
    }
}
