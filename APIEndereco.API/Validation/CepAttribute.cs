using System.ComponentModel.DataAnnotations;

namespace APIEndereco.API.Validation
{
    public class CepAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? cep = value as string;

            if(cep.Length != 8)
            {
                return new ValidationResult("CEP must have 8 characters!");
            }

            if (!cep.All(c => char.IsDigit(c)))
            {
                return new ValidationResult("CEP must contain only numbers!");
            }

            return ValidationResult.Success;
        }
    }
}
