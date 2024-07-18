using APIEndereco.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace APIEndereco.API.Requests
{
    public class CreateAddressRequest
    {
        [Required]
        [Cep]
        [StringLength(8)]
        public string Cep { get; set; }
    }
}
