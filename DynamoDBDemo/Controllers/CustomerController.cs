using DynamoDBDemo.DTOs;
using DynamoDBDemo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var data = await customerRepository.Get(id);
            return Ok(data);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var data = await customerRepository.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Customer customer)
        {
            await customerRepository.CreateOrUpdate(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await customerRepository.Delete(id);
            return Ok();
        }
    }
}
