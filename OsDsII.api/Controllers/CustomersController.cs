using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Services;
using OsDsII.api.Http;
using OsDsII.api.Dto;

namespace OsDsII.api.Controllers

{

    [ApiController]

    [Route("[controller]")]

    public class CustomersController : ControllerBase

    {
        private readonly ICustomersService _customersService;

        public CustomersController(DataContext dataContext, ICustomersService customersService)

        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

        {
            try
            {
                IEnumerable<Customer> customers = await _customersService.GetAllCustomersAsync();
                IEnumerable<CustomerDto> customersDto = customers.Select(c => c.ToCustomer());
                return HttpResponseApi<IEnumerable<CustomerDto>>.Ok(customersDto);
            }
            catch (Exception ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            try
            {
                Customer customer = await _customersService.GetCustomerByIdAsync(id);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                Customer currentCustomer = await _customersService.CreateCustomerAsync(customer);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer currentCustomer = await _customersService.UpdateCustomerAsync(id, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            try
            {
                Customer customer = await _customersService.GetCustomerByIdAsync(id);
                await _customersService.DeleteCustomerAsync(id, customer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }

}