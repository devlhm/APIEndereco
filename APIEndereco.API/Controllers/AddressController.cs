using APIEndereco.API.Requests;
using APIEndereco.API.Validation;
using APIEndereco.Application;
using APIEndereco.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APIEndereco.API.Controllers
{
    [Route("api/cep")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAddressRequest request)
        {
            try
            {
                await _addressService.CreateByCep(request.Cep);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Created();
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> Get([Required, Cep] string cep)
        {
            try
            {
                var result = await _addressService.GetByCep(cep);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
